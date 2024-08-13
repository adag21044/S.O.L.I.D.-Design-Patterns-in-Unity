using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetGetter 
{
    List<Transform> GetTargets(Transform transform);
}