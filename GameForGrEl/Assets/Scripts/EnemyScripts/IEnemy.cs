using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 
{
 ParticleSystem Particle{get;set;}
 SpriteRenderer Renderer{get;set;}
 void FindPlayer();
 int Damage{get;set;}
 Vector2 Sizes{get;set;}
 float WaitTime{get;set;}
 float Health{get;set;}
 float Speed{get;set;}
 
 void Move();
 void Attack();
 void TakeDamge(float _damage);
 void OnDead();
 void OnSetActiveEnemy();
 void Turn(Transform _transform, Vector3 _size);
 bool IsTurned{get;set;}
 IEnumerator CoolDown();
 bool IsCoolDown{get;set;}
}
