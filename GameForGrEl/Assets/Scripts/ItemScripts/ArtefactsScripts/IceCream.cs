using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCream : Item, IItem 
{

    [SerializeField] private IceCreamData _iceCream;
    public override void OnRemove()
    {
       _iceCream.Bullet.transform.localScale = new Vector3(0.75f,0.75f,1);
    }

    public  void PickUpEvent()
    {
        _iceCream.Bullet.transform.localScale = new Vector3(5,5,5);
    }
}
