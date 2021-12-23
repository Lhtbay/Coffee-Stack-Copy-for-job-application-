using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_sc : MonoBehaviour
{
    [Header("Cups Settings")]
    [SerializeField] float _speed;
    [SerializeField] private float _minX, _maxX;
    [SerializeField] private float _speedMoveSide;

    [SerializeField] GameManager_sc _managerScript;

    private bool _gameIsStart = false;

    void Update()
    {
        if (_gameIsStart)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minX, _maxX), transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speedMoveSide);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speedMoveSide);
        }

    }
    private void FixedUpdate()
    {
        _gameIsStart = _managerScript.gameStart;
    }
}
