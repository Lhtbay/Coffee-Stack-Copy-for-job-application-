using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeve_sc : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
