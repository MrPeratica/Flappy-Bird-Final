using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyManager : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotateSpeed = 10f;
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip _jumpClip; 
    [SerializeField] private AudioClip _hitClip;

    private Rigidbody2D rigidbody2d;
    private AudioSource _audioSource;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameManager.instance.IsGameOver) return;

        bool jumpPressed = false;

       
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            jumpPressed = true;
        }

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            jumpPressed = true;
        }

        
        if (jumpPressed)
        {
           
            if (Time.timeScale == 0)
            {
                GameManager.instance.StartGame();
            }

         
            rigidbody2d.velocity = Vector2.up * _velocity;
            
            if (_audioSource != null && _jumpClip != null)
            {
                _audioSource.PlayOneShot(_jumpClip);
            }
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rigidbody2d.velocity.y * _rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_audioSource != null && _hitClip != null)
        {
            _audioSource.PlayOneShot(_hitClip);
        }

        GameManager.instance.GameOver();
    }  
}