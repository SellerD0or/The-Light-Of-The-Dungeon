using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour, IBullet
{
        [SerializeField] private float _speed; 
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private float _waitTime = 2;
    [SerializeField] private float _damage = 2f;
    private Character _character;

    public float Speed { get => _speed; set => _speed = value; }
    public float Damage { get => _damage; set => _damage = value; }
    public float WaitTime { get => _waitTime; set => _waitTime = value; }
    public Character Character { get => _character; set => _character = value; }
    private Vector3 _target;

    private void Start() 
    {
      //  _target = Character.transform.position;
        _particle.Play();
        Destroy(gameObject, WaitTime);
    }
    public void GetPlayer(Character _character) => Character = _character;
    private void Update() 
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<Character>(out Character _character))
        {
            _character.TakeDamage((int)Damage);
        }
    }
}
