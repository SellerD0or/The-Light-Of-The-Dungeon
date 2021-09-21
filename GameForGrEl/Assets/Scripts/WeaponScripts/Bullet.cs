using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private float _speed; 
    private Inventory _invenory;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private float _waitTime = 2;
    [SerializeField] private float _damage = 2f;
    private Character _character;

    public float Speed { get => _speed; set => _speed = value; }
    public float Damage { get => _damage; set => _damage = value; }
    public float WaitTime { get => _waitTime; set => _waitTime = value; }
    public Character Character { get => _character; set => _character = value; }

    private void Start() 
    {
        Character = FindObjectOfType<Character>();
        _particle.Play();
        _invenory = FindObjectOfType<Inventory>();
        _invenory.PickUpEvents?.Invoke();
        Delete(WaitTime);
        Character.DestroyAction += Destroy;
    }
    private void OnDisable() 
    {
        Character.DestroyAction -= Destroy;
    }
    public void Destroy() => Delete(0);
    private void Delete(float _destroyTime) => Destroy(gameObject, _destroyTime);
    private void Update() {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<IEnemy>(out IEnemy _enemy))
        {
            _enemy.TakeDamge(Damage);
            Destroy(gameObject);
        }
    }
}
