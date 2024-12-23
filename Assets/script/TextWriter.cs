using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{

    private Text uiText;          // Reference to the Text UI component
    private string textToWrite;   // The text that will be typed out
    private int characterIndex;   // Current character index
    private float timePerCharacter; // How long to wait between each character
    private float timer;          // Timer to track character display timing
    private bool isTextComplete = false; // To track if the text is fully typed

    // Method to start the text-writing effect
    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.characterIndex = 0;  // Reset character index
        this.timer = timePerCharacter;  // Initialize the timer to timePerCharacter
        this.isTextComplete = false;   // Reset the completion flag
        uiText.text = ""; // Start with an empty text
    }

    // Update is called once per frame
    private void Update()
    {
        // Memeriksa apakah uiText ada (tidak null)
    // if (uiText == null)
    // {
    //     // Jika uiText null, tampilkan pesan kesalahan
    //     Debug.LogError("UI Text component is missing or not assigned!");
    //     return; // Keluar dari fungsi Update jika uiText null
    // }
    // else
    // {
    //     // Jika uiText ada, tampilkan log bahwa fungsi Update berjalan
    //     Debug.Log("Update function is running and uiText is assigned.");

    // }
        if (uiText != null && !isTextComplete)
        {
            timer -= Time.deltaTime;  // Decrease the timer
            if (timer <= 0f)
            {
                // Display the next character
                timer += timePerCharacter;  // Reset the timer
                characterIndex++;  // Move to the next character

                if (characterIndex <= textToWrite.Length)
                {
                    uiText.text = textToWrite.Substring(0, characterIndex);  // Update the UI text
                }

                if (characterIndex == textToWrite.Length)
                {
                    isTextComplete = true; // Mark the text as complete
                }
            }
        }
    }

    // Method to check if the text is complete
    public bool IsTextComplete()
    {
        return isTextComplete;
    }
}
