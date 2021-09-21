using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _spawnPosition;
    private Vector3 _size;

    public Vector3 Size { get => _size; set => _size = value; }
    

    [SerializeField] private Transform _particlePosition;

    private void Start() {
        _particle.Pause();
        Size = transform.localScale;
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
           _particlePosition.position = _spawnPosition.position;
           _particle.gameObject.transform.rotation = transform.rotation;
           _particle.Play();
           Bullet _prefabBullet = Instantiate(_bullet, _spawnPosition.position, Quaternion.identity);
           _prefabBullet.transform.rotation =transform.rotation;
        }
    }
}
