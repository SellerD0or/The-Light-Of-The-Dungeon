using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    
}
class Program
{
    static void Main(string[] args)
    {
        Developer dev = new PanelDeveloper("ООО КирпичСтрой");
        House house2 = dev.Create();
         
        dev = new WoodDeveloper("Частный застройщик");
        House house = dev.Create();
     }
}
// абстрактный класс строительной компании
abstract class Developer
{
    public string Name { get; set; }
 
    public Developer (string n)
    { 
        Name = n; 
    }
    // фабричный метод
    abstract public House Create();
}
// строит панельные дома
class PanelDeveloper : Developer
{
    public PanelDeveloper(string n) : base(n)
    { }
 
    public override House Create()
    {
        return new PanelHouse();
    }
}
// строит деревянные дома
class WoodDeveloper : Developer
{ 
    public WoodDeveloper(string n) : base(n)
    { }
 
    public override House Create()
    {
        return new WoodHouse();
    }
}
 
abstract class House
{ 
    public abstract void Destroy();
}
 
class PanelHouse : House 
{ 
    public PanelHouse()
    {
        Debug.Log("Panel");
    }

    public override void Destroy()
    {
        
    }
}
class WoodHouse : House
{ 
    public WoodHouse()
    {
        Debug.Log("Wood");
    }

    public override void Destroy()
    {
        
    }
}
