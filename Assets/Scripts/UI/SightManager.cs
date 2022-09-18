using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SightManager : MonoBehaviour
{
    [SerializeField] private PlayerSight _playerSight;
    [SerializeField] private FirstPersonController _firstPersonController;
    private CanvasGroup _canvasGroup;
    private LockCamera _lockCamera;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _lockCamera = GetComponent<LockCamera>();
        _lockCamera.enabled = false;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_canvasGroup.interactable == false)
            {
                ShowButtons();
            }
            else
            {
                CloseButtons();
            }
        }
    }

    public void TryMark(int rotation)
    {
        CloseButtons();
        _playerSight.Mark(rotation);
    }

    private void ShowButtons()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        _firstPersonController.enabled = false;
    }

    private void CloseButtons()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _firstPersonController.enabled = true;
    }

}
