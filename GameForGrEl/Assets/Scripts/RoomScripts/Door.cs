using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfDoor
{
    _top,
    _bottom,
    _right,
    _left
}
public class Door : MonoBehaviour
{
   [SerializeField] private TypeOfDoor _typeOfDoor;

    public TypeOfDoor TypeOfDoor { get => _typeOfDoor; set => _typeOfDoor = value; }
 [SerializeField] private GameObject _roomPoint;
   private bool _isOpen = true;
  [SerializeField] private SpriteRenderer _spriteRenderer;
  [SerializeField] private Color[] _colors;

    public bool IsOpen { get => _isOpen; set => _isOpen = value; }
    private void Start() 
    {
        SetChanges();
    }


    public void ChangeCondition()
 {
     IsOpen =! IsOpen;
     int _action = IsOpen ? 1 : 0;
     _spriteRenderer.color = _colors[_action];
     SetChanges();
 }
 private void SetChanges() => _roomPoint.SetActive(IsOpen);
 

}
