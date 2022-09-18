using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private EndLevelTrigger _endLevelTrigger;
    [SerializeField] private Magazine _magazine;
    [SerializeField] private GameObject _winLable;
    [SerializeField] private GameObject _failLable;
    [SerializeField] private GameObject _panelFinish;
    [SerializeField] private Button _buttonRestart;

    private void OnEnable()
    {
        _endLevelTrigger.LevelLost += OnFail;
        _magazine.Won += OnWin;
        _buttonRestart.onClick.AddListener(OnRestartLevel);
    }

    private void OnDisable()
    {
        _endLevelTrigger.LevelLost -= OnFail;
        _magazine.Won -= OnWin;
        _buttonRestart.onClick.RemoveListener(OnRestartLevel);
    }

    private void OnFail()
    {
        _panelFinish.SetActive(true);
        _failLable.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnWin()
    {
        _panelFinish.SetActive(true);
        _winLable.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnRestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
