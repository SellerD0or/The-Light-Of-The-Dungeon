using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet 
{
    float Speed{get;set;}
    float Damage{get;set;}
    float WaitTime{get;set;}
    Character Character{get;set;}
    void OnTriggerEnter2D(Collider2D other);
}
