using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRooms : MonoBehaviour
{
    private Room _room;
    [SerializeField] private Room[] _rooms;
    private bool _isSpawned;

    public bool IsSpawned { get => _isSpawned; set => _isSpawned = value; }
     private MiniMap _miniMap;

    private void Start() 
    {
        _room = GetComponentInParent<Room>();
         _miniMap = FindObjectOfType<MiniMap>();
        StartCoroutine(CreateRoom());
    }
    private IEnumerator CreateRoom()
    {
        yield return new WaitForSeconds(0.1f);
        int random = Random.Range(0,_rooms.Length);
        Instantiate(_rooms[random].gameObject, transform.position, Quaternion.identity);
        IsSpawned = true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.TryGetComponent<SpawnRooms>(out SpawnRooms _spawn) && _spawn.IsSpawned )|| other.GetComponent<Room>())
        {
            _room.SpawnRooms.Remove(this);
            Destroy(gameObject);
        }
    }
}
