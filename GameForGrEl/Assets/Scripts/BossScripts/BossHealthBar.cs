using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _health;
    public Image _healthBar;
    private float fillValue;

    public GameObject Health { get => _health; set => _health = value; }

    public  void TakeDamage(ChefKiller _boss)
    {
        fillValue = (float)_boss.Health;
        fillValue = fillValue / _boss.MaxHealth;
        _healthBar.fillAmount = fillValue;
    }
}
