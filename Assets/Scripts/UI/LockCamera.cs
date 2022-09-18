using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCamera : MonoBehaviour
{
    void Update()
    {
        Camera.main.transform.rotation = Camera.main.transform.rotation;
    }
}
