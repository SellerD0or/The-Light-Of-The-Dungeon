using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform _heartsPosition;
    [SerializeField] private HeartContainer _heartContainer;
      private List< HeartContainer> _heartContainers = new List<HeartContainer>();
      private UnityAction _takeDamageAction;
      private  delegate void _d();

    public void CreateContainers(Character _character) 
    {
        for (int i = 0; i < _character.MaxHealth; i++)
        {
          AddHeart();
         // _takeDamageAction += _heart.TakeDamage;
        }
    }
    public void AddHeart()
    {
        HeartContainer _heart =  Instantiate(_heartContainer, transform.position, Quaternion.identity);
          _heart.transform.SetParent(_heartsPosition, false);
          _heartContainers.Add(_heart);
    }

    public void Heal(Character _character) =>_heartContainers[_character.Health - 1].Heal();
    
    public void TakeDamage(Character _character) => _heartContainers[_character.Health] .TakeDamage();
    
}
