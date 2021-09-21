using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Text _text;
  private int _countOfMoney;
    public void AddMoney()
    {
        _countOfMoney++;
        _text.text = _countOfMoney.ToString();
    }
}
