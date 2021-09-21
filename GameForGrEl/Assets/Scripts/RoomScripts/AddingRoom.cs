using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingRoom : MonoBehaviour
{
 [SerializeField] private List<Room> _rooms = new List<Room>();
  [SerializeField] private Room _bossRoom;
  [SerializeField] private Room _treasureRoom;
  [SerializeField] private Room _storeRoom;
  private Transform _roomPoint;
  private void Start() {
      StartCoroutine(SpawnRooms());
  }
  public void AddRoom(Room room) => _rooms.Add(room);
  
  private IEnumerator SpawnRooms()
  {
      yield return new WaitForSeconds(6);
      
    //  Room _shopRoom = _rooms[_rooms.Count - 4];
      //foreach (var _spawnPoint in _shopRoom.SpawnRooms)
   //   {
         // _spawnPoint.gameObject.SetActive(true);
   //   }
  //    int _random1 = Random.Range(0, _shopRoom.SpawnRooms.Count);
      //Instantiate(_storeRoom, _shopRoom.SpawnRooms[_random1].transform.position ,Quaternion.identity);

    //   Room _enemyRoom = _rooms[_rooms.Count - 1];
     // foreach (var _spawnPoint in _enemyRoom.SpawnRooms)
     // {
        //  _spawnPoint.gameObject.SetActive(true);
    //  }
   //   int _random2 = Random.Range(0, _enemyRoom.SpawnRooms.Count);
      //Instantiate(_bossRoom, _enemyRoom.SpawnRooms[_random2].transform.position ,Quaternion.identity);
      TurnOnSpawnPoints(_bossRoom, 1);
      TurnOnSpawnPoints(_treasureRoom, 2);
      TurnOnSpawnPoints(_storeRoom, 4);
      
  }
  private void TurnOnSpawnPoints(Room _additionalRoom, int _countOfCurrentRoom)
  {
      Room _room = _rooms[_rooms.Count - _countOfCurrentRoom];
         foreach (var _spawnPoint in _room.SpawnRooms)
      {
          _spawnPoint.gameObject.SetActive(true);
      }
      StartCoroutine(CreateRoom(_room, _additionalRoom));
  }
  private IEnumerator CreateRoom(Room _room, Room _additionalRoom)
  {
      yield return new WaitForSeconds(1);
      int _numberSpawnPoint = Random.Range(0, _room.SpawnRooms.Count);
      Instantiate(_additionalRoom, _room.SpawnRooms[_numberSpawnPoint].transform.position ,Quaternion.identity);
  }
}
