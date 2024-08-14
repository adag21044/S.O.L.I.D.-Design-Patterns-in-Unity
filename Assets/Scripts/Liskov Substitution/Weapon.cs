using UnityEngine;

public class Weapon : Item
{
    [SerializeField] private int damage = 10;

    public int Damage => damage;

    public override void DisplayText()
    {
        Debug.Log($"{Name} : When You Swing Me I Deal {Damage} damage!");
    }
}