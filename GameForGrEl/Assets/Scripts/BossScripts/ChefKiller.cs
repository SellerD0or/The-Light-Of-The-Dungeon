using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefKiller : Boss, IEnemy
{
       [SerializeField] private ParticleSystem _particle;
    private bool _isCoolDown;
    [SerializeField] private GameObject _miniGun;
    [SerializeField] private EnemyArrow _enemyBullet;  
    [SerializeField] private Transform _bulletPostion;
     [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private float _waitTime;
     private BossRoom _bossRoom;
     [SerializeField] private int _damage = 1;
    [SerializeField]  private float _health = 100;
    [SerializeField] private float _speed = 5f;
    private Character _character;
    public float Health { get => _health; set => _health = value ;}
    public float Speed { get => _speed; set => _speed = value;}
    public  Vector2 Sizes { get; set; }

    [SerializeField] private float _range = 5f;
    public bool IsTurned{get;set;}
    public  int Damage { get => _damage; set => _damage = value; }
    public  float WaitTime { get => _waitTime; set => _waitTime = value; }
    public SpriteRenderer Renderer { get => _renderer; set => _renderer = value; }
    public bool IsCoolDown { get => _isCoolDown; set => _isCoolDown = value; }
    public ParticleSystem Particle { get => _particle; set => _particle = value; }
    public override float MaxHealth { get; set; }

    private Vector3 _miniGunSizes;
    private float _angle;
    private BossHealthBar _bossHealthBar;
    private LoadScene _loadScene;
    

    private void Start() 
    {
        _loadScene = FindObjectOfType<LoadScene>();
        _bossHealthBar = FindObjectOfType<BossHealthBar>();
        MaxHealth = Health;
        _particle.Pause();
        _miniGunSizes = _miniGun.transform.localScale;
        Sizes = transform.localScale;
        FindPlayer();
    }
    public void FindHealthBar(BossHealthBar _enemyHealthBar) => _enemyHealthBar = _bossHealthBar;
    private void Update() 
    {
             IsTurned = transform.position.x >=  _character.transform.position.x;
           Turn(transform, Sizes);
           Vector2 _direction = transform.position - _character.transform.position;
            _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
           _miniGun.transform.rotation = Quaternion.Euler(_miniGun.transform.rotation.x, _miniGun.transform.rotation.y, _angle);
           Turn(_miniGun.transform, _miniGunSizes);
           if (Vector3.Distance(transform.position, _character.transform.position) < _range)
          {
              if(!IsCoolDown)
              {
              Attack();
              StartCoroutine(CoolDown());
              }
          }
          else
          {
              Move();
          }
        
    }
 

    public void OnDead()
    {
         Destroy(gameObject);
    }

    public void Move()
    { 
        transform.position = Vector2.MoveTowards(transform.position,_character.transform.position, _speed * Time.deltaTime);
        
    }

    public void TakeDamge(float _damage)
    {
        _bossHealthBar.TakeDamage(this);
        _particle.Play();
        Health -=  _damage;
        StartCoroutine(ChangeColor());
        if (Health <= 0)
        {
            OnSetActiveEnemy();
           
            //Destroy(gameObject);
           // _action?.Invoke();
        }
    }

    public void FindPlayer() =>  _character = FindObjectOfType<Character>();

    public  void SpawnEnemy(BossRoom room)
    {
        _bossRoom = room;
    }
    public void OnSetActiveEnemy()
    {
        _bossRoom.InvokeDestroyAction();
        Destroy(gameObject);
        _loadScene.StartCoroutine(_loadScene.Won());
       
    }

    public void Turn(Transform _transform, Vector3 _size)
    {
        float _turn = IsTurned ?-_size.x : _size.x;
       _transform.localScale = new Vector3(_turn, _transform.localScale.y, _transform.localScale.z);
       
    }
        public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Character>(out Character _character))
        {
            _character.TakeDamage(Damage);
        }
    }
        public IEnumerator ChangeColor()
    {
          Renderer.color = Color.red;     
          yield return new WaitForSeconds(WaitTime *2);
          Renderer.color = Color.white;
    }

    public IEnumerator CoolDown()
    {
        _isCoolDown = true;
        yield return new WaitForSeconds(WaitTime);
        _isCoolDown = false;
    }

    public void Attack()
    {        
       EnemyArrow _enemyArrow = Instantiate(_enemyBullet,_bulletPostion.position, Quaternion.identity);
       _enemyArrow.transform.rotation = Quaternion.Euler(_enemyArrow.transform.rotation.x, _enemyArrow.transform.rotation.y,_angle + 180);
    }
}
