using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "IceCreamData", menuName = "GameForGrEl/IceCreamData", order = 0)]
public class IceCreamData : ScriptableObject {
    [SerializeField] private Bullet _bullet;

    public Bullet Bullet { get => _bullet; set => _bullet = value; }
}
