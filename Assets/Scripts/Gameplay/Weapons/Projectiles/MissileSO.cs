using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewML", menuName = "ScriptableObjects/Missile", order = 51)]
public class MissileSO : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name => _name;

    [SerializeField] private float _speed;
    public float Speed => _speed;

    [SerializeField] private float _damage;
    public float Damage => _damage;   
    
    [SerializeField] private bool _aiming;
    public bool Aiming => _aiming;

    [SerializeField] private Sprite _icon;
    public Sprite Icon => _icon;
}

