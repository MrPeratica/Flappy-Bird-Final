using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _highScore;
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip _scoreClip;      // Drag your "Point" sound here
    [SerializeField] private AudioClip _highScoreClip;  // Drag your "High Score" sound here

    private int score;
    private const string HighScoreKey = "highScore";    // Fixed key to prevent bugs
    private bool _hasPlayedHighScoreSound = false;      // Ensures high score sound only plays once

    private AudioSource _audioSource; 
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // Get the AudioSource component
        _audioSource = GetComponent<AudioSource>();

        _currentScore.text = score.ToString();
        _highScore.text = PlayerPrefs.GetInt(HighScoreKey, 0).ToString();
    }

    private void RefreshHighScore()
    {
        // Check if we beat the saved high score
        if (score > PlayerPrefs.GetInt(HighScoreKey))
        {
            PlayerPrefs.SetInt(HighScoreKey, score);
            _highScore.text = score.ToString();
            PlayerPrefs.Save();

            // Play High Score sound (only once per game)
            if (!_hasPlayedHighScoreSound && _audioSource != null && _highScoreClip != null)
            {
                _audioSource.PlayOneShot(_highScoreClip);
                _hasPlayedHighScoreSound = true; 
            }
        }
    }

    public void RefreshScore()
    {
        score++;
        _currentScore.text = score.ToString();

        // --- NEW: Play Point Sound ---
        if (_audioSource != null && _scoreClip != null)
        {
            _audioSource.PlayOneShot(_scoreClip);
        }
        // -----------------------------

        RefreshHighScore();
    }
}