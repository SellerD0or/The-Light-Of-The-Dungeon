using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
  [SerializeField] private List<Item> _collectionOfItems;
    private UnityAction _PickUpEvents;
  private List<IItem> _items = new List<IItem>();
    public UnityAction PickUpEvents { get => _PickUpEvents; set => _PickUpEvents = value; }
    public UnityAction DestroyEvent { get => _DestroyEvent; set => _DestroyEvent = value; }

    private UnityAction _DestroyEvent;

    private void Start() 
    {
     foreach (Item _item in _collectionOfItems)
     {
         _DestroyEvent += _item.OnRemove;
     }
     _DestroyEvent?.Invoke();
      PickUpEvents =null;
    }
    private void SetEvents() => _DestroyEvent?.Invoke();
  private void OnTriggerEnter2D(Collider2D other) {
      if (other.TryGetComponent<IItem>(out IItem _item))
      {
          _items.Add(_item);
          Destroy(other.gameObject);
          PickUpEvents += _item.PickUpEvent;
      }
  }
}
