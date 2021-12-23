using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_sc : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private Transform _targetTransform;

    [SerializeField] private float _smoothValue;

    [SerializeField] private Vector3 _offSetLocation;
    private Vector3 _newPosition;

    #endregion
    
    void Update()
    {
        _newPosition = _targetTransform.position + _offSetLocation;

        transform.position = Vector3.Lerp(transform.position, _newPosition, _smoothValue);
    }
}
