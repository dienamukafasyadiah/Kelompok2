using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; // Untuk perpindahan Scene

public class MainMenuManager : MonoBehaviour
{
    public InputField nameInputField;  // Variabel untuk InputField

    public void SaveNameAndGoToNextScene()
    {
        string playerName = nameInputField.text;  // Ambil teks dari InputField
        
        // Validasi nama agar tidak kosong
        if (!string.IsNullOrEmpty(playerName))    
        {
            PlayerPrefs.SetString("PlayerName", playerName);  // Simpan nama ke PlayerPrefs
            SceneManager.LoadScene("HubDunia");         // Pindah ke scene berikutnya
        }
        else
        {
            Debug.Log("Nama harus diisi!"); // Validasi jika pengguna belum mengisi nama
        }
    }
}
