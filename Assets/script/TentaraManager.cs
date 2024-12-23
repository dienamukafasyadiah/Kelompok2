using UnityEngine;
using System.Collections.Generic;

public class TentaraManager : MonoBehaviour
{
    public List<GameObject> tentaraList; // List tentara
    public UI_Assistant uiAssistant;    // Referensi ke UI_Assistant

    void Update()
    {
        if (uiAssistant != null && uiAssistant.messageDone)
        {
            // Aktifkan tentara setelah cerita selesai
            SetTentaraAktif(true);
        }
    }

    private void SetTentaraAktif(bool status)
    {
        foreach (GameObject tentara in tentaraList)
        {
            // Pastikan objek tentara tidak null sebelum mencoba mengaksesnya
            if (tentara != null)
            {
                tentara.SetActive(status); // Mengatur setiap tentara aktif/tidak
            }
            else
            {
                Debug.LogWarning("Tentara object is null and cannot be set active.");
            }
        }
    }
}
