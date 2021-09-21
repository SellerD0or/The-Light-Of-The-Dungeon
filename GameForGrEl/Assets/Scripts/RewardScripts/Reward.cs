using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reward : MonoBehaviour
{
   public abstract PolygonCollider2D Collider{get;set;}
   public abstract int CreateChance{get;set;}
   public IEnumerator TurnOnCollider()
   {
       yield return new WaitForSeconds(0.5f);
       Collider.isTrigger = true;
   }
}
