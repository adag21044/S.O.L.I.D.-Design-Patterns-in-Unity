using System.Collections.Generic;
using UnityEngine;

public class SelfTargetting : MonoBehaviour, ITargetGetter
{
    public List<Transform> GetTargets(Transform transform)
    {
        return new List<Transform> { transform };
    }
}