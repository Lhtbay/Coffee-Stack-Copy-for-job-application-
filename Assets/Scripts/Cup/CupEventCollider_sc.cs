using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupEventCollider_sc : MonoBehaviour
{
    [SerializeField] private GameObject _thisLidObject;
    [SerializeField] private GameObject _thisCartoonObject;
    [SerializeField] private GameObject _thisCup;

    [SerializeField] private CupCopy_sc _cupCopyScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lid")
        {
            _thisLidObject.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "cartoon")
        {
            _thisCartoonObject.SetActive(true);
        }
        if (this.gameObject.tag == "event" && other.gameObject.tag == "sell")
        {
            _cupCopyScript.IsSell = true;
        }
    }
    public void TakeGrass()
    {
        _cupCopyScript.TakeHand();
    }
    public GameObject GiveCupObject()
    {
        return _thisCup;
    }

}
