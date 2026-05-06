using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject startPanel;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject successPanel;
    
    [Header("UI References")]
    public GameObject pauseButton; // Drag your PauseButton here
    
    private bool isPaused = false;
    private bool isGameActive = false; // Track if game is running
    
    void Start()
    {
        Time.timeScale = 0f;
        isGameActive = false;
        
        if (startPanel != null) startPanel.SetActive(true);
        if (pausePanel != null) pausePanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (successPanel != null) successPanel.SetActive(false);
        
        // Make sure pause button is hidden until game starts
        if (pauseButton != null) pauseButton.SetActive(false);
    }
    
    void Update()
    {
        // Only allow pause if game is active AND not game over/success
        if (isGameActive && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }
    
    public void StartGame()
    {
        if (startPanel != null) startPanel.SetActive(false);
        isGameActive = true;
        
        // Show pause button when game starts
        if (pauseButton != null) pauseButton.SetActive(true);
        
        ResumeGame();
    }
    
    public void PauseGame()
    {
        if (!isGameActive) return; // Don't pause if game is over
        
        Time.timeScale = 0f;
        isPaused = true;
        if (pausePanel != null) pausePanel.SetActive(true);
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        if (pausePanel != null) pausePanel.SetActive(false);
    }
    
    // Call this when player dies / game over
    public void GameOver()
    {
        if (!isGameActive) return;
        
        isGameActive = false;
        isPaused = false;
        Time.timeScale = 0f;
        
        // Hide pause button and pause panel
        if (pauseButton != null) pauseButton.SetActive(false);
        if (pausePanel != null) pausePanel.SetActive(false);
        
        // Show game over panel
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        
        Debug.Log("GAME OVER!");
    }
    
    // Call this when player wins / succeeds
    public void GameSuccess()
    {
        if (!isGameActive) return;
        
        isGameActive = false;
        isPaused = false;
        Time.timeScale = 0f;
        
        // Hide pause button and pause panel
        if (pauseButton != null) pauseButton.SetActive(false);
        if (pausePanel != null) pausePanel.SetActive(false);
        
        // Show success panel
        if (successPanel != null) successPanel.SetActive(true);
        
        Debug.Log("SUCCESS!");
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Game Restarted");
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}