using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckDoor : MonoBehaviour
{
    [SerializeField] private Door _door;
    private bool _isChecked;
    [SerializeField] private GameObject _wall;
    [SerializeField] private Room _room;
    private void Awake() {
        _room = GetComponentInParent<Room>();
      StartCoroutine(DestroyDoor());
    }
    private IEnumerator DestroyDoor()
    {
        yield return new WaitForSeconds(0.15f);
         if (!_isChecked)
        {
            Destroy(_door.gameObject);
        }
        else
        {
              _room.DestroyAction += _door.ChangeCondition;
        }
    }
private void OnTriggerEnter2D(Collider2D other) 
{
    if (other.TryGetComponent<Room>(out Room room))
    {
      int active = (int)_door.TypeOfDoor;
      room.Doors[active].gameObject.SetActive(true);
      _isChecked = true;
      
      
    }
}
}
