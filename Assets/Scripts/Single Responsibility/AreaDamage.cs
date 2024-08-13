using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private int damageToDeal = 10;

    public void ApplyDamage(Vector3 explosionCenter)
    {
        Collider[] colliders = Physics.OverlapSphere(explosionCenter, explosionRadius);

        foreach (var collider in colliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.DealDamage(damageToDeal);
            }
        }
    }
}
