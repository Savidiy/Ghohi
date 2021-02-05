using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportProvider : MonoBehaviour
{
    [SerializeField] Transform _target;
    public void TeleportToPoint(Transform point)
    {
        _target.position = point.position;
    }
}
