using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Assistant : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;  // Komponen TextWriter untuk efek mengetik
    [SerializeField] private Text messageText;       // Referensi teks tempat pesan ditampilkan
    [SerializeField] private List<string> messageArray = new List<string>(); // Daftar pesan untuk ditampilkan
    [SerializeField] public bool messageDone;        // Status apakah semua pesan selesai

    [SerializeField] private GameObject soldier;     // Referensi ke GameObject tentara

    private int currentMessageIndex = 0;             // Indeks pesan saat ini
    private CanvasGroup canvasGroup;                // Untuk mengontrol visibilitas UI

    private void Awake()
    {
        // Validasi TextWriter
        if (textWriter == null)
        {
            Debug.LogError("TextWriter tidak disiapkan. Pastikan untuk menetapkan di Inspector.");
        }

        // Validasi Text dan menambahkan Button jika belum ada
        if (messageText == null)
        {
            Debug.LogError("MessageText tidak disiapkan. Pastikan untuk menetapkan di Inspector.");
        }
        else
        {
            Button button = messageText.GetComponent<Button>();
            if (button == null)
            {
                Debug.LogWarning("Tidak ditemukan Button di MessageText. Menambahkan Button otomatis.");
                button = messageText.gameObject.AddComponent<Button>();
            }
            button.onClick.AddListener(OnTextClicked); // Tambahkan event listener untuk klik teks
        }

        // Siapkan CanvasGroup untuk visibilitas UI
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogWarning("CanvasGroup tidak ditemukan. Menambahkan CanvasGroup otomatis.");
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        // Pastikan GameObject tentara disiapkan
        if (soldier != null)
        {
            soldier.SetActive(false); // Matikan tentara di awal
        }
    }

    private void Start()
    {
        // Mengambil nama pemain dari PlayerPrefs
        string playerName = PlayerPrefs.GetString("PlayerName", "Pemain");

        // Mengganti placeholder {PlayerName} dengan nama pemain
        for (int i = 0; i < messageArray.Count; i++)
        {
            messageArray[i] = messageArray[i].Replace("{PlayerName}", playerName);
        }

        // Mulai menampilkan pesan pertama
        if (textWriter != null && messageText != null && messageArray.Count > 0)
        {
            messageDone = false;
            textWriter.AddWriter(messageText, messageArray[currentMessageIndex], 0.01f);
        }
        else if (messageArray.Count == 0)
        {
            Debug.LogError("Message array kosong. Tambahkan pesan di Inspector.");
        }
    }

    private void OnTextClicked()
    {
        // Jika teks selesai, pindah ke pesan berikutnya
        if (textWriter != null && textWriter.IsTextComplete())
        {
            currentMessageIndex++;
            if (currentMessageIndex < messageArray.Count)
            {
                textWriter.AddWriter(messageText, messageArray[currentMessageIndex], 0.01f);
            }
            else
            {
                Debug.Log("Semua pesan telah ditampilkan.");
                ShowSoldier(); // Tampilkan tentara
                HideUI();      // Sembunyikan UI
                messageDone = true;
            }
        }
    }

    // Fungsi untuk menyembunyikan UI
    private void HideUI()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0; // Sembunyikan UI dengan mengatur transparansi
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            Debug.LogError("CanvasGroup tidak ditemukan. UI tidak dapat disembunyikan.");
        }
    }

    // Fungsi untuk menampilkan tentara
    private void ShowSoldier()
    {
        if (soldier != null)
        {
            soldier.SetActive(true); // Aktifkan GameObject tentara
            Debug.Log("Tentara telah muncul.");
        }
        else
        {
            Debug.LogError("Referensi ke tentara tidak disiapkan. Pastikan diatur di Inspector.");
        }
    }
}
