using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTeleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(7, 1, 7);
    }
}
