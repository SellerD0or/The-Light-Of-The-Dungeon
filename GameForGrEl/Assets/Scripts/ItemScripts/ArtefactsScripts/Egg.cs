using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : Item, IItem
{
    [SerializeField] private EggData _egg;
      private void Start() {
       _egg. Character = FindObjectOfType<Character>();
    }
    public override void OnRemove()
    {
       _egg.Character.ReturnMaxHealth();
    }

    public  void PickUpEvent()
    {
        _egg.Character.AddHealth();
    }
}
