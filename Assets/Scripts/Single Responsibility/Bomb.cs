using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float secondsUntilDetonation = 3f;
    [SerializeField] private LayerMask explodeOnContactLayermask = new LayerMask();
    private AreaDamage areaDamage;

    private void Start()
    {
        areaDamage = GetComponent<AreaDamage>();
        StartCoroutine(Timer());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & explodeOnContactLayermask) != 0)
        {
            Detonate();
        }
    }

    private void Detonate()
    {
        areaDamage.ApplyDamage(transform.position);
        Destroy(gameObject);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(secondsUntilDetonation);
        Detonate();
    }
}
