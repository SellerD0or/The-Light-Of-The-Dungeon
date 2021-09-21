using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBandit : Enemy, IEnemy
{
     [SerializeField] private ParticleSystem _particle;
    private bool _isCoolDown;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private float _waitTime;
     private Room _currentRoom;
     [SerializeField] private int _damage = 1;
    [SerializeField]  private float _health = 1;
    [SerializeField] private float _speed = 5f;
    private Character _character;
    public float Health { get => _health; set => _health = value ;}
    public float Speed { get => _speed; set => _speed = value;}
    public override bool IsActive {get; set;}
    public  Vector2 Sizes { get; set; }

    [SerializeField] private float _range = 5f;
    public bool IsTurned{get;set;}
    public  int Damage { get => _damage; set => _damage = value; }
    public  float WaitTime { get => _waitTime; set => _waitTime = value; }
    public SpriteRenderer Renderer { get => _renderer; set => _renderer = value; }
    public bool IsCoolDown { get => _isCoolDown; set => _isCoolDown = value; }
    public ParticleSystem Particle { get => _particle; set => _particle = value; }

    private float _extraSpeed;
    private float _currentSpeed;
    private void Start() 
    {
        _particle.Pause();
        _extraSpeed = _speed*1.5f;
        Sizes = transform.localScale;
        FindPlayer();
    }
    private void Update() 
    {
        if(IsActive)
        {
             
             IsTurned = transform.position.x >= _character.transform.position.x;
           Turn(transform, Sizes);
        bool _haveDistance = Vector2.Distance(transform.position, _character.transform.position) < _range;
         _currentSpeed = _haveDistance ? _extraSpeed : _speed;
        Move();
        }
        
    }
    public void Attack() => _character.TakeDamage(Damage);
    public void OnDead() => Destroy(gameObject);

    public void Move()
    { 
        transform.position = Vector2.MoveTowards(transform.position,_character.transform.position, _currentSpeed * Time.deltaTime);
        
    }

    public void TakeDamge(float _damage)
    {
        _particle.Play();
        Health -=  _damage;
        StartCoroutine(ChangeColor());
        if (Health <= 0)
        {
            OnSetActiveEnemy();
            OnDead();
            //Destroy(gameObject);
           // _action?.Invoke();
        }
    }

    public void FindPlayer() =>  _character = FindObjectOfType<Character>();

    public override void SpawnEnemy(Room room)
    {
         IsActive = true;
        _currentRoom = room;
    }
    public void OnSetActiveEnemy()
    {
        _currentRoom.RemoveEnemy(this);
       
    }

    public void Turn(Transform _transform, Vector3 _size)
    {
        float _turn = IsTurned ?-_size.x : _size.x;
       _transform.localScale = new Vector3(_turn, _transform.localScale.y, _transform.localScale.z);;
    }
        public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Character>(out Character _character))
        {
            Attack();
        }
    }
        public IEnumerator ChangeColor()
    {
          Renderer.color = Color.red;     
          yield return new WaitForSeconds(WaitTime / 20);
          Renderer.color = Color.white;
    }

    public IEnumerator CoolDown()
    {
        _isCoolDown = true;
        yield return new WaitForSeconds(WaitTime);
        _isCoolDown = false;
    }
}
