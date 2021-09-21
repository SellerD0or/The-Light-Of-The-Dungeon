using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Room : MonoBehaviour
{
  [SerializeField] private bool _isSimpleRoom;
  private UnityAction _DestroyAction;
    [SerializeField] private Transform[] _spawnPosition;
  [SerializeField] private Color[] _colors;
   [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Door[] _doors;
    public Door[] Doors { get => _doors; set => _doors = value; }
    public UnityAction DestroyAction { get => _DestroyAction; set => _DestroyAction = value; }
    public List<SpawnRooms> SpawnRooms { get => _spawnRooms; set => _spawnRooms = value; }

    [SerializeField] private List<SpawnRooms> _spawnRooms ;
    private AddingRoom _addingRoom;
   [SerializeField]  private bool _isEmptyRoom;
   private bool _isOpen;
    [SerializeField] private Enemy[]  _enemies;
    private List<Enemy> _currentEnemies= new List<Enemy>();
    private float _waitTime = 0.3f;
    [SerializeField] private Reward[] _rewards;
    private int _totalReward;
    private void Start() 
    {
      if(_isSimpleRoom)
      {
        _addingRoom = FindObjectOfType<AddingRoom>();
        _addingRoom.AddRoom(this);
      }
      
        
    }
    private void CreateLoot()
    {
      
      foreach (var _item in _rewards)
      {
        _totalReward += _item.CreateChance;
      }
      int _randomLoot = Random.Range(0, _totalReward + 4);
      for (int i = 0; i < _rewards.Length; i++)
      {
          if (_randomLoot <= _rewards[i].CreateChance)
          {
              Instantiate(_rewards[i], transform.position, Quaternion.identity);
          }
          else
          {
            _randomLoot -= _rewards[i].CreateChance;
          }
      }
    }
    public void CreateRoom()
    {
       if(!_isOpen && !_isEmptyRoom)
      {
        DestroyAction?.Invoke();
       StartCoroutine(SummonEnemy());
       _isOpen = true;
       DestroyAction += CreateLoot;
      }
    }
    private IEnumerator SummonEnemy()
    {
      yield return new WaitForSeconds(_waitTime);
        foreach (Transform currentPosition in _spawnPosition)
       {
         int random = Random.Range(0, _enemies.Length);
          Enemy _enemy = Instantiate(_enemies[random], currentPosition.position, Quaternion.identity);
          _enemy.SpawnEnemy(this);
          _currentEnemies.Add(_enemy);

       }
    }
     public void SetActiveRoom(bool _isActive) 
    {
      
      int _currentNumberOfColor = _isActive ? 0 : 1;
       _spriteRenderer.color= _colors[_currentNumberOfColor];
    }
      public void RemoveEnemy(Enemy _enemy)
  {
      _currentEnemies.Remove(_enemy);
     if (_currentEnemies.Count <= 0)
      {
         DestroyAction?.Invoke();
      }
  }
}
