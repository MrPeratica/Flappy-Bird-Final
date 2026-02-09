using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI References")]
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _tapToStartImage; 
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
        Time.timeScale = 0f;

        if (_tapToStartImage != null) _tapToStartImage.SetActive(true);
        if (_getReadyImage != null) _getReadyImage.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;

      
        if (_tapToStartImage != null) _tapToStartImage.SetActive(false);
        if (_getReadyImage != null) _getReadyImage.SetActive(false);

      
        ScoreManager.instance.SetScoreVisible(true);
    }

    public void GameOver()
    {
        IsGameOver = true;
        _losePanel.SetActive(true);
        Time.timeScale = 0f;

        
        ScoreManager.instance.SetScoreVisible(false);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}