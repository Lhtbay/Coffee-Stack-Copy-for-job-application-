using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCopy_sc : MonoBehaviour
{
    GameObject _beforeObject;
    public bool IsSell = false;

    private CupEvent_sc _cupEventScript;

    [Header("Settings")]
    [SerializeField] float _lerpValue;
    [SerializeField] float _multiplierValue;
    [SerializeField] float _speed;

    private Vector3 _futurePosition;

    private float _time = 0;
    private int _listIndexNumber;

    private void Start()
    {
        _cupEventScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CupEvent_sc>();
    }

    private void Update()
    {
        if (!IsSell)
        {
            _listIndexNumber = _cupEventScript.IndexOfValue(this.gameObject);
            _beforeObject = _cupEventScript._copyCupsList[_listIndexNumber - 1];

            _futurePosition = new Vector3(
            Mathf.Lerp(transform.position.x, _beforeObject.transform.position.x, _lerpValue * Time.deltaTime * _multiplierValue),
            transform.position.y,
            _beforeObject.transform.position.z + 1);
            transform.position = _futurePosition;
        }
        else
        {
            transform.Translate(Vector3.left*Time.deltaTime*_speed);
            _time += Time.deltaTime;
            if (_time >=1.5f)
            {
                _cupEventScript._copyCupsList.RemoveAt(_listIndexNumber);
                Destroy(this.gameObject);
            }
        }
    }
}
