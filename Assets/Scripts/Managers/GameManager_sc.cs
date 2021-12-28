using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager_sc : MonoBehaviour
{
    public bool gameStart = false;

    [SerializeField] private GameObject _cupObject;
    [SerializeField] private GameObject _startCanvasObject;
    [SerializeField] private TextMeshProUGUI _moneyTmpro;

    private int _money = 0;

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
        _moneyTmpro.text = _money.ToString();
    }

 
    public void AddMoney(int value)
    {
        _money += value;
    }
    public int HowMoney()
    {
        return _money;
    }
}
