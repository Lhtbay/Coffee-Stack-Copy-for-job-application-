using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCopy_sc : MonoBehaviour
{
    public GameObject _beforeObject;

    [SerializeField] float _lerpValue;

    private Vector3 _futurePosition,_newPosition;
 
    private void Update()
    {
        _futurePosition = new Vector3(
            Mathf.Lerp(transform.position.x,_beforeObject.transform.position.x,_lerpValue*Time.deltaTime*1),
            transform.position.y,
            _beforeObject.transform.position.z+1);
        transform.position = _futurePosition;
    }
}
