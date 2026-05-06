using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimplePause : MonoBehaviour
{
    private bool isPaused = false;
    private Button button;
    private TextMeshProUGUI buttonText;
    
    void Start()
    {
        // Get the button component on this same object
        button = GetComponent<Button>();
        
        // Get the text component from the child
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        
        // Add the pause function to the button click
        button.onClick.AddListener(TogglePause);
        
        Debug.Log("Pause script started!"); // This will appear in Console if working
    }
    
    void TogglePause()
    {
        // Toggle pause state
        isPaused = !isPaused;
        
        // Freeze or unfreeze the game
        if (isPaused)
        {
            Time.timeScale = 0f;  // Game pauses
            Debug.Log("Game PAUSED");
        }
        else
        {
            Time.timeScale = 1f;  // Game resumes
            Debug.Log("Game RESUMED");
        }
        
        // Change button text
        buttonText.text = isPaused ? "Resume" : "Pause";
    }

    void Update()
    {
        // This ensures Space never unpauses accidentally
       // It does nothing - just prevents any accidental pause toggles
    }
}