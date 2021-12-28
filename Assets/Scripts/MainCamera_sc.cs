using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_sc : MonoBehaviour
{
    #region FIELDS
    
    [Header("Finish Settings")]
    [SerializeField] Movement_sc _movementScript;
    [SerializeField] CupEvent_sc _cupEvenctScript;
    [SerializeField] Sounds_Manager_sc _soundsScript;
    [SerializeField] Transform _finishLocation;
    [SerializeField] float _camSlideSpeed;
    [SerializeField] float _speed;
    [SerializeField] Camera _mainCamera;

    [SerializeField] private float _smoothValue;

    [SerializeField] private Transform _targetTransform;

    [SerializeField] private Vector3 _offSetLocation;

    private bool _oneTime, _translateUp = true;
    private bool _isFinished,_isMoveToLocation = false;
    private int _listCount, _skore,_skoreNameİnt,_centSkore;
    private string _skoreString;
    private Animator _thisAnim;

    private Vector3 _newPosition;

    #endregion

    private void Start()
    {
        _thisAnim = this.gameObject.GetComponent<Animator>();
        _mainCamera = this.gameObject.GetComponent<Camera>();

        _oneTime = true;
        _translateUp = true;
        _isFinished = false;
    }

    void Update()
    {
       
        if (!_movementScript.isActiveAndEnabled && !_isMoveToLocation)
        {
            transform.position = Vector3.MoveTowards(transform.position,_finishLocation.position,_camSlideSpeed);

            if (transform.position == _finishLocation.position)
            {
                _isMoveToLocation = true;
            }

            if (_oneTime)
            {
                _listCount = _cupEvenctScript._copyCupsList.Count;
                _skore = _listCount * 50;                             
                _skoreString = _skore.ToString();
                _thisAnim.SetTrigger("cam");
                _oneTime = false;
                _isFinished = true;                
           }
        }
        else if (_translateUp && !_isFinished)
        {
            _newPosition = _targetTransform.position + _offSetLocation;

            transform.position = Vector3.Lerp(transform.position, _newPosition, _smoothValue);
        }
        if (!_oneTime && _translateUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime * _speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _skoreNameİnt = int.Parse(other.gameObject.name);
        if (_skoreNameİnt > 0)
        {
            _soundsScript.AwardsSounds();
        }
        if (other.gameObject.name == _skoreString)
        {
            _translateUp = false;
            _mainCamera.fieldOfView = 20;
        }
    }
}
