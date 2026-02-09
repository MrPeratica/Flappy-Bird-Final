using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float _speedPipe = 0.7f;

    private void Update()
    {
        transform.position += Vector3.left * _speedPipe * Time.deltaTime;
    }
    
}
