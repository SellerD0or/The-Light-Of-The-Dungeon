using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossRoom : MonoBehaviour
{
    private bool _isActiveHealthBar;
    [SerializeField] private ChefKiller _boss;
     private Room _currentRoom;

    public Room CurrentRoom { get => _currentRoom; set => _currentRoom = value; }
    private bool _isBossSummoned;
    private BossHealthBar _bossHealthBar;

    private void Start() 
    {
        _bossHealthBar = FindObjectOfType<BossHealthBar>();
        _currentRoom.GetComponent<Room>();
    }
   private void OnTriggerEnter2D(Collider2D other) 
   {
    if (other.GetComponent<Character>())
    {
      
     if (!_isBossSummoned)
     {
         
        ChefKiller _killer = Instantiate(_boss, transform.position, Quaternion.identity);  
        _killer.FindHealthBar(_bossHealthBar);
        _killer.SpawnEnemy(this);
        InvokeDestroyAction();
         _isBossSummoned  = true;
     }  
    }
   }
   public void InvokeDestroyAction() 
   {
       _isActiveHealthBar =! _isActiveHealthBar;
       _bossHealthBar.Health.SetActive(_isActiveHealthBar);
       _currentRoom?.DestroyAction.Invoke();
   }
}
