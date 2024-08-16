using UnityEngine;

public class ConstantMovement : MonoBehaviour, IMovementInputGetter
{
    public float Horizontal => 1f;
    public float Vertical => 1f;
}