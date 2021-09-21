using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Reward
{

     [SerializeField] private PolygonCollider2D _collider;
      [SerializeField] private int _createChance = 1;
   public override int CreateChance { get => _createChance; set => _createChance = value; }

    public override PolygonCollider2D Collider { get => _collider; set => _collider = value; }
    [SerializeField] private GameObject[] _rewards;
    [SerializeField]  private Sprite _sprite;
    [SerializeField] private SpriteRenderer _renderer;
    private int _countOfCreating;
    private int _currentCountOfCreating;

    private void Start() 
    {
        StartCoroutine(TurnOnCollider());
       _countOfCreating = Random.Range(1, 4);
       CreateItems();
    }
    private void CreateItems()
    {
        _renderer.sprite = _sprite;
        int _randomVariant = Random.Range(0,_rewards.Length);
       Instantiate(_rewards[_randomVariant], transform.position, Quaternion.identity);
       
       _currentCountOfCreating ++;
       if (_currentCountOfCreating < _countOfCreating)
       {
           CreateItems();
       }
    }
        private void OnTriggerEnter2D(Collider2D other) 
  {
      if (other.GetComponent<Character>())
      {
          CreateItems();
          Destroy(gameObject);
      }
  }
}
