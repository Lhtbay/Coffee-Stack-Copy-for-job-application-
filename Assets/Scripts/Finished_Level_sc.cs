using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished_Level_sc : MonoBehaviour
{
    [SerializeField] private GameObject[] _transformPositionObject;
    [SerializeField] private CupEvent_sc _cupEventScript;

    private int _listCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            _listCount = _cupEventScript._copyCupsList.Count;
            
            for (int i = _listCount-1; i > 0; i--)
            {               
                GameObject transform = _transformPositionObject[i];
                _cupEventScript.FinishLevel(i, transform);
            }
        }
    }
}
