using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1f;
    [SerializeField] private float _yPosRange = 0.50f;
    [SerializeField] private GameObject _pipe;

    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        PipeSpawn();
    }


    private void PipeSpawn()
    {
        Vector3 pipePos = transform.position+new Vector3(0,UnityEngine.Random.Range(-_yPosRange, _yPosRange));
        GameObject Pipe = Instantiate(_pipe, pipePos, Quaternion.identity);
        Destroy(Pipe, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > _maxTime)
        {
            PipeSpawn();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }
}
