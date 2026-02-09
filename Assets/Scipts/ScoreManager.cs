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
    [SerializeField] private AudioClip _scoreClip;      
    [SerializeField] private AudioClip _highScoreClip;  

    private int score;
    private const string HighScoreKey = "highScore";    
    private bool _hasPlayedHighScoreSound = false;      

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

        _audioSource = GetComponent<AudioSource>();

        _currentScore.text = score.ToString();
        _highScore.text = PlayerPrefs.GetInt(HighScoreKey, 0).ToString();
    }

    private void RefreshHighScore()
    {
    
        if (score > PlayerPrefs.GetInt(HighScoreKey))
        {
            PlayerPrefs.SetInt(HighScoreKey, score);
            _highScore.text = score.ToString();
            PlayerPrefs.Save();

            
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

       
        if (_audioSource != null && _scoreClip != null)
        {
            _audioSource.PlayOneShot(_scoreClip);
        }
     

        RefreshHighScore();
    }
}