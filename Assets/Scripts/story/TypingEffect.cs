using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text textComponent; // Teks yang akan dianimasikan.
    public string[] messages; // Daftar teks.
    public float typingSpeed = 0.05f; // Kecepatan mengetik.

    private int currentMessageIndex = 0; // Indeks teks saat ini.
    private bool isTyping = false; // Status animasi mengetik.

    void Start()
    {
        StartTyping();
    }

    public void OnClick()
    {
        if (isTyping)
        {
            // Langsung tampilkan teks penuh jika sedang mengetik.
            StopAllCoroutines();
            textComponent.text = messages[currentMessageIndex];
            isTyping = false;
        }
        else
        {
            // Lanjut ke teks berikutnya.
            currentMessageIndex++;
            if (currentMessageIndex < messages.Length)
            {
                StartTyping();
            }
            else
            {
                textComponent.text = ""; // Kosongkan jika teks habis.
            }
        }
    }

    void StartTyping()
    {
        isTyping = true;
        textComponent.text = ""; // Kosongkan sebelum mengetik.
        StartCoroutine(TypeMessage());
    }

    IEnumerator TypeMessage()
    {
        foreach (char c in messages[currentMessageIndex])
        {
            textComponent.text += c; // Tambahkan karakter satu per satu.
            yield return new WaitForSeconds(typingSpeed); // Tunggu sebelum karakter berikutnya.
        }
        isTyping = false;
    }
}
