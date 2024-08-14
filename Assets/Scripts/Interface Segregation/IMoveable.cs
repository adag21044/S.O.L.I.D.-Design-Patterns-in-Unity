using UnityEngine;

public interface IMoveable
{
    int Speed { get; }
    Vector3 Position { get; }
    void Move(Vector3 direction);
}