using UnityEngine;
using UnityEngine.Events;

public class ColliderOverlap : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrigger = new UnityEvent();
    [SerializeField] private LayerMask layerMask = new LayerMask();

    private void OnCollisionEnter(Collision collision)
    {
        if(((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            onTrigger?.Invoke();
        }
    } 
}