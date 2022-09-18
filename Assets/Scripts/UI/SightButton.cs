using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SightButton : MonoBehaviour
{
    [SerializeField] private int _rotateAngle;
    [SerializeField] private SightManager _sightManager;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
    }


    public void ButtonClickListener()
    {
        _sightManager.TryMark(_rotateAngle);
    }
}
