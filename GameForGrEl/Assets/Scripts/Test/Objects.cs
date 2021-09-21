using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{

}
public class Player
{
    private int _speed;

    public int Speed { get => _speed; set => _speed = value; }
    public int Health { get => _health; set => _health = value; }

    private int _health;
    public void ApplyDamage(int _damage)
    {
        if(_damage > 0)
        {
      _health -= _damage;
        }

    }
    public void Heal(int _additionHealth)
    {
        _health += _additionHealth;
    }
}
public abstract class Vilager 
{
    protected IMove _imove;
    protected ITrade _itrade;
    protected IAttack _iattack;
    protected abstract void ChangeVillageBehaviors();
}
public class PoliceOfficer : Vilager
{
    protected override void ChangeVillageBehaviors()
    {
        _imove = new BadRunner();
        _iattack = new BanditAttack();
    }
}
public class BadRunner : IMove
{
    public void Move(Player _player, int _speed)
    {
        Debug.Log($"{_player.Speed} my speed: {_speed} know, I run more slowly");
    }
}
public class GoodRunner: IMove
{
    public void Move(Player _player, int _speed)
    {
        _speed *= 4;
        Debug.Log($"{_player.Speed} my speed: {_speed} know, I run more faster");
    }
}
public class GoodTrader
{
    public GoodTrader(string _name)
    {
        Debug.Log(_name + "he is good trader");
    }
}
public interface IMove
{
    void Move(Player _player, int _speed);
}
public interface ITrade
{
    void Trade(Player _player, int _coin);
}
public class BanditAttack : IAttack
{
    public void Attack(Player _player, int _damage)
    {
        _player.ApplyDamage(_damage * 3);
    }
}
public class HealthAttack : IAttack
{
    public void Attack(Player _player, int _damage)
    {
        _player.Heal(_damage / 2);
    }
}
public interface IAttack
{
    void Attack(Player _player, int _damage);
}
