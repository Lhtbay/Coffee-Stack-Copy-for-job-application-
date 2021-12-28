using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupEventCollider_sc : MonoBehaviour
{
    [SerializeField] private GameObject _thisLidObject;
    [SerializeField] private GameObject _thisCartoonObject;
    [SerializeField] private GameObject _thisCup;

    [SerializeField] private CupCopy_sc _cupCopyScript;

    private Sounds_Manager_sc _soundsScript;
    private GameManager_sc _gameManagerScript;

    private void Start()
    {
        _soundsScript = GameObject.FindGameObjectWithTag("sounds").GetComponent<Sounds_Manager_sc>();
        _gameManagerScript = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager_sc>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lid")
        {
            _thisLidObject.gameObject.SetActive(true);
            _soundsScript.LidClosedSounds();
            _gameManagerScript.AddMoney(5);
        }
        if (other.gameObject.tag == "cartoon")
        {
            _thisCartoonObject.SetActive(true);
            _soundsScript.SleveeSounds();
            _gameManagerScript.AddMoney(10);
        }
        if (this.gameObject.tag == "event" && other.gameObject.tag == "sell")
        {
            _cupCopyScript.IsSell = true;
            _soundsScript.SellSounds();
            _gameManagerScript.AddMoney(5);
        }
    }
    public void TakeGrass()
    {
        _cupCopyScript.TakeHand();
        _soundsScript.TakeHandSounds();
    }
    public GameObject GiveCupObject()
    {
        return _thisCup;
    }

}
