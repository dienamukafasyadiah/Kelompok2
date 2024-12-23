using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleporter : MonoBehaviour{
    public string destinationSceneName;  // Nama scene tujuan
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Load scene tujuan
            SceneManager.LoadScene(destinationSceneName);
        }
    }
}