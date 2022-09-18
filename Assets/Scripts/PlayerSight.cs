using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSight : MonoBehaviour
{
   [SerializeField] private GameObject _sight;
   [SerializeField] private float _sightRetreat;

   public void Mark(int rotation)
   {
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         Debug.DrawRay(transform.position, transform.forward * 10, Color.green);

         if (Physics.Raycast(ray, out hit))
         {
            GameObject sight = Instantiate(_sight, hit.point, Quaternion.identity);
            sight.transform.LookAt(Camera.main.transform);
            sight.transform.rotation = Quaternion.Euler(sight.transform.rotation.x,sight.transform.rotation.y, rotation);
         }
   }
}
