using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms_sc : MonoBehaviour
{
    [SerializeField] private Transform _cupToHandTrasform;
    [SerializeField] private GameObject _armObject;
    [SerializeField] bool _rightSide = true;

    private BoxCollider _thisCollider;
    private Animator _thisAnim;

    private GameObject _colliderObject;

    private bool _oneTime = true;

    private void Start()
    {
        _thisCollider = this.gameObject.GetComponent<BoxCollider>();
        _thisAnim = _armObject.gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "event" && _oneTime)
        {
            _thisCollider.enabled = false;
            _oneTime = false;

            _colliderObject = other.gameObject.GetComponent<CupEventCollider_sc>().GiveCupObject();

            other.gameObject.GetComponent<CupEventCollider_sc>().TakeGrass();
            _colliderObject.transform.position = _cupToHandTrasform.position;
            _colliderObject.transform.parent = _armObject.transform;

            if (_rightSide)
            {
                _thisAnim.SetTrigger("take");
            }
            else
            {
                _thisAnim.SetTrigger("take2");
            }
        }
    }
}
