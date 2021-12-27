using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupEvent_sc : MonoBehaviour
{
    public List<GameObject> _copyCupsList;

    [SerializeField] private GameManager_sc _gameManagerScript;
    [SerializeField] private float _moveTowardsSpeed;

    private BoxCollider _playerCollider;

    private int _indexNumber;
    private int _indexValueOther;

    private void Start()
    {
        _copyCupsList = new List<GameObject>();
        _copyCupsList.Add(this.gameObject);

        _playerCollider = this.GetComponent<BoxCollider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cup")
        {           
            _copyCupsList.Add(other.gameObject);
           
            //other.gameObject.GetComponent<CupCopy_sc>()._beforeObject = _copyCupsList[_copyCupsList.IndexOf(other.gameObject)-1];
            _indexNumber = (_copyCupsList.IndexOf(other.gameObject)-1);

            other.gameObject.transform.position = new Vector3(
                _copyCupsList[_indexNumber].transform.position.x,
                _copyCupsList[_indexNumber].transform.position.y,
                _copyCupsList[_indexNumber].transform.position.z+1);
                

            other.gameObject.GetComponent<CupCopy_sc>().enabled = true;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;

            //other.gameObject.transform.parent = this.transform;

            other.gameObject.GetComponent<Animator>().SetTrigger("isStart");

            other.transform.position = new Vector3(
                _copyCupsList[(_copyCupsList.Count-1)].transform.position.x,
                _copyCupsList[(_copyCupsList.Count-1)].transform.position.y,
                _copyCupsList[(_copyCupsList.Count-1)].transform.position.z + 1);

            _playerCollider.center = new Vector3(
                _playerCollider.center.x,
                _playerCollider.center.y,
                _playerCollider.center.z+1);

            _playerCollider.size = new Vector3(
                _playerCollider.size.x,
                _playerCollider.size.y,
                _playerCollider.size.z+2);          
        }    
    }
    public int IndexOfValue (GameObject ObjectValue)
    {
        _indexValueOther = _copyCupsList.IndexOf(ObjectValue);
        return _indexValueOther;
    }
    public void FinishLevel(int value , GameObject Obj)
    {
        _copyCupsList[value].GetComponent<CupCopy_sc>().Finished();
        _copyCupsList[value].GetComponent<CupCopy_sc>().FinishedGame(_moveTowardsSpeed,Obj);

        _copyCupsList.RemoveAt(value);
    }
}
