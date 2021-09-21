using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Reward
{
    
    [SerializeField] private PolygonCollider2D _collider;
     [SerializeField] private int _createChance = 2;
   public override int CreateChance { get => _createChance; set => _createChance = value; }

    public override PolygonCollider2D Collider { get => _collider; set => _collider = value; }
     private void Start() {
        StartCoroutine(TurnOnCollider());
    }
     private void OnTriggerEnter2D(Collider2D other) 
     {
      if (other.TryGetComponent<Character>(out Character _character) && _character.Health < _character.MaxHealth)
      {
          _character.Heal();
          Destroy(gameObject);
      }
  }
}
