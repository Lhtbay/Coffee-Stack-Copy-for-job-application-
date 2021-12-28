using UnityEngine;

public class SellMachineBoard_sc : MonoBehaviour
{
    [SerializeField] private float _speedX;

    private float _cury;

    private void Start()
    {
        _cury = GetComponent<Renderer>().material.mainTextureOffset.y;

    }
    private void FixedUpdate()
    {
        _cury += Time.deltaTime * _speedX;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex" , new Vector2(0, _cury));
    }
}
