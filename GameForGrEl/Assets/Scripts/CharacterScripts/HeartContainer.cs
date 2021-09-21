using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartContainer : MonoBehaviour
{
   [SerializeField] private  List<Color> _colors =new List<Color>();
   [SerializeField] private Image _icon;
   public void Heal() => _icon.color = _colors[1];
    public void TakeDamage() => _icon.color = _colors[0];
    
}
