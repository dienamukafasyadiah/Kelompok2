using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public string portalID;  // ID portal ini

    private void Start()
    {
        // Cek apakah pemain datang dari portal lain
        string lastPortalID = PlayerPrefs.GetString("LastPortalID", "");
        
        if (lastPortalID == portalID)
        {
            // Temukan player
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // Posisikan player di depan portal
                player.transform.position = transform.position + transform.forward * 2f;
                player.transform.rotation = transform.rotation;
            }
            
            // Reset portal terakhir
            PlayerPrefs.DeleteKey("LastPortalID");
        }
    }
}