using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PortalTrigger : MonoBehaviour
{
    public string targetScene;  // Nama scene yang akan dituju
    public GameObject videoCanvas;  // Objek VideoCanvas
    public float videoDuration = 12f;  // Durasi video dalam detik

    private void Start()
    {
        // Pastikan VideoCanvas tidak aktif saat permainan dimulai
        if(videoCanvas != null)
        {
            videoCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Pastikan yang masuk ke trigger adalah pemain
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PlayVideoAndLoadScene());
        }
    }

    private IEnumerator PlayVideoAndLoadScene()
    {
        // Aktifkan Video Canvas untuk memutar video
        videoCanvas.SetActive(true);

        // Tunggu selama durasi video
        yield return new WaitForSeconds(videoDuration);

        // Pindah ke scene tujuan setelah video selesai
        SceneManager.LoadScene(targetScene);

        // Nonaktifkan VideoCanvas agar UI lain bisa berfungsi setelah scene dimuat
        videoCanvas.SetActive(false);
    }
}
