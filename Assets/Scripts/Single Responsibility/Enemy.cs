using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 10;

    public void DealDamage(int damage)
    {
        health = Mathf.Max(0, health - damage);

        if (health == 0) Destroy(gameObject);
    }
}
