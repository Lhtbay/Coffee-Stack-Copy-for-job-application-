using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkoreText_sc : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _skoreTextMeshPro;

    private void Start()
    {
        this.gameObject.name = _skoreTextMeshPro.text;
    }

}
