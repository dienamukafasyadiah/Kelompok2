using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterNameManager : MonoBehaviour
{
    public InputField nameInputField;  // Reference to the input field
    public Text nameDisplayText;       // Optional: Reference to a Text field to display the name

    // Function to retrieve the name from the input field and proceed to the game
    public void StartGame()
    {
        string playerName = nameInputField.text;

        // If you want to display the player's name in a text field (optional)
        if (nameDisplayText != null)
        {
            nameDisplayText.text = "Welcome, " + playerName + "!";
        }

        // Load the scene (you can change "GameScene" to your actual scene name)
        SceneManager.LoadScene("GameScene");
    }
}
