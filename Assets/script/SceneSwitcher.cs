using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Fungsi untuk berpindah scene berdasarkan nama
    public void ChangeSceneByName(string sceneName)
    {
        Debug.Log("Switching to Scene: " + sceneName); // Debug log untuk memastikan pemanggilan
        SceneManager.LoadScene(sceneName);
    }
}
