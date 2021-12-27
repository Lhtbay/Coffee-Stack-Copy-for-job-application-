﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCopy_sc : MonoBehaviour
{
    GameObject _beforeObject;
    public bool IsSell = false;
    public GameObject _moveObj;
    public float _finishedSpeed;

    private CupEvent_sc _cupEventScript;

    [Header("Settings")]
    [SerializeField] float _lerpValue;
    [SerializeField] float _multiplierValue;
    [SerializeField] float _speed;

    private Vector3 _futurePosition;

    private float _time = 0;

    private int _listIndexNumber;

    private bool _removeListBool = true;
    private bool _ısTake = false;
    private bool _ısFinish = false;

    private void Start()
    {
        _cupEventScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CupEvent_sc>();
    }

    private void Update()
    {
        _listIndexNumber = _cupEventScript.IndexOfValue(this.gameObject);

        if (!IsSell && !_ısTake && !_ısFinish)
        {           
            _beforeObject = _cupEventScript._copyCupsList[_listIndexNumber - 1];

            _futurePosition = new Vector3(
            Mathf.Lerp(transform.position.x, _beforeObject.transform.position.x, _lerpValue * Time.deltaTime * _multiplierValue),
            transform.position.y,
            _beforeObject.transform.position.z + 1);
            transform.position = _futurePosition;
        }
        else if (!_ısTake && !_ısFinish)
        {
            transform.Translate(Vector3.left*Time.deltaTime*_speed);
            _time += Time.deltaTime;

            if (_removeListBool)
            {
                _cupEventScript._copyCupsList.RemoveAt(_listIndexNumber);
                _removeListBool = false;
            }
            
            if (_time >=1f)
            {               
                Destroy(this.gameObject);
            }
        }
        else if (_ısFinish)
        {
            transform.position = Vector3.MoveTowards(transform.position,_moveObj.transform.position,_finishedSpeed);
        }
    }

    public void TakeHand()
    {
        _cupEventScript._copyCupsList.RemoveAt(_listIndexNumber);
        _ısTake = true;
    }
    public void Finished()
    {
        _ısFinish = true;
    }
    public void FinishedGame(float _speed , GameObject obj)
    {
        _moveObj = obj;
        _finishedSpeed = _speed;
    }
}
