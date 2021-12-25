using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_sc : MonoBehaviour
{
    public bool gameStart = false;

    [SerializeField] private GameObject _cupObject;
    [SerializeField] private GameObject _startCanvasObject;


    private void FixedUpdate()
    {
        if (gameStart==false)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                gameStart = true;
                _startCanvasObject.SetActive(false);
                _cupObject.GetComponent<Animator>().SetTrigger("isStart");
            }
        }
    }
}
