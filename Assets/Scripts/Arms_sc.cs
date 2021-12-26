using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms_sc : MonoBehaviour
{
    [SerializeField] private Transform _cupToHandTrasform; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "event")
        {
            print("gg");
            collision.gameObject.GetComponent<CupCopy_sc>().TakeHand();
            collision.gameObject.transform.position = _cupToHandTrasform.position;
            collision.gameObject.transform.parent = this.transform;
        }
    }
}
