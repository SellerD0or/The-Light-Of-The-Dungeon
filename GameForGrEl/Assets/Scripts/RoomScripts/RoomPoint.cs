using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPoint : MonoBehaviour
{
    [SerializeField] private Transform _roomPosition;
  private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.TryGetComponent<Character>(out Character _character))
      {
          other.transform.position = _roomPosition.position;
         
           
      }
  }
}
