using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI References")]
    [SerializeField] private GameObject _losePanel;
    
    // 1. We keep your original Tap image (the hand tutorial)
    [SerializeField] private GameObject _tapToStartImage; 
    
    // 2. We add the NEW Get Ready image (the text)
    [SerializeField] private GameObject _getReadyImage; 

    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        IsGameOver = false;
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        // Pause game at start
        Time.timeScale = 0f;

        // Show BOTH images
        if (_tapToStartImage != null)
        {
            _tapToStartImage.SetActive(true);
        }
        
        if (_getReadyImage != null)
        {
            _getReadyImage.SetActive(true);
        }
    }

    public void StartGame()
    {
        // Unpause game
        Time.timeScale = 1f;

        // Hide BOTH images
        if (_tapToStartImage != null)
        {
            _tapToStartImage.SetActive(false);
        }

        if (_getReadyImage != null)
        {
            _getReadyImage.SetActive(false);
        }
    }

    public void GameOver()
    {
        IsGameOver = true;
        _losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}