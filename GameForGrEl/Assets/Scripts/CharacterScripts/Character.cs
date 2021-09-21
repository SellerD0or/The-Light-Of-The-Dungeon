using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Character : MonoBehaviour
{
  [SerializeField] private Wallet _wallet;
  private UnityAction _destroyAction;
   [SerializeField] private float _waitTime = 2f;
   [SerializeField] private int _health;
  private int _maxHealth;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    [SerializeField] private Camera _miniMap;
    private Camera _camera;
     private bool isTurned;
     private Vector2 _sizes;
    private Vector3 _mousePosition;
    [SerializeField] private Gun _gun;
      [SerializeField]private HealthBar _healthBar;
      private bool _canTakeDamage;
    public int Health { get => _health; set => _health = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public UnityAction DestroyAction { get => _destroyAction; set => _destroyAction = value; }
    public Wallet Wallet { get => _wallet; set => _wallet = value; }
    public HealthBar HealthBar { get => _healthBar; set => _healthBar = value; }
    private LoadScene _loadScene;
    private int _startMaxHealth;
    private void Start() 
    {
      
      _loadScene = FindObjectOfType<LoadScene>();
         MaxHealth =Health;
         _startMaxHealth = _maxHealth;
        _sizes =   transform.localScale;
         _camera = Camera.main;
         HealthBar.CreateContainers(this);
    }
    public void ReturnMaxHealth() => _maxHealth = _startMaxHealth;
    private void Update() 
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
          Vector2 _direction = _mousePosition - _gun.transform.position;
        float _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
       _gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle ));


        float _movementX = Input.GetAxis("Horizontal");
        Vector2 _movemnt = new Vector2(_movementX, Input.GetAxis("Vertical"));
        _rigidbody2D.velocity = _movemnt * _speed;
        if(_movementX != 0)
       {
           isTurned = _movementX > 0;
           Turn(_gun.transform, _gun.Size );
           Turn(transform, _sizes);
       }
    }
      public void SetRoom(Room room)
    {
     
         _camera.transform.position = new Vector3( room.transform.position.x, room.transform.position.y, -10);
         _miniMap.transform.position = _camera.transform.position;
    }
      private void Turn(Transform _transform, Vector2 _objectSizes) 
    {
       float _turn = isTurned ?_objectSizes.x : -_objectSizes.x;
       _transform.localScale = new Vector3(_turn, _transform.localScale.y, _transform.localScale.z);;
   }
   public void AddHealth()
   {
     Heal();
     _maxHealth++;
     HealthBar.AddHeart();
   }
   public void Heal() 
   {
     _health++;
     HealthBar.Heal(this);
   }
   public void TakeDamage(int _damage)
   {
     if(!_canTakeDamage)
     {
     _health -= _damage;
     HealthBar.TakeDamage(this);
     if (_health <= 0)
     {
       _loadScene.LoadMenu();
     }
     StartCoroutine(CoolDown());
     }
   }
   private void OnTriggerEnter2D(Collider2D other) 
   {
        if (other.TryGetComponent<Room>(out Room _room))
      {
         DestroyAction?.Invoke();
          _room.SetActiveRoom(true);
          _room.CreateRoom();
        SetRoom(_room);
      }
      
      
   }
   private void OnTriggerExit2D(Collider2D other) 
   {
           if (other.TryGetComponent<Room>(out Room _room))
       {
          _room.SetActiveRoom(false);
       }
      }
        public IEnumerator CoolDown()
    {
      _canTakeDamage = true;
        yield return new WaitForSeconds(_waitTime);
      _canTakeDamage = false;
    }
}
