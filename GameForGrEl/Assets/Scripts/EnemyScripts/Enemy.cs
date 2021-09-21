using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class Enemy : MonoBehaviour
{
      public abstract bool IsActive{get;set;}
      public abstract void SpawnEnemy(Room room);
}
