using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction Died;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Died?.Invoke();
    }
}
