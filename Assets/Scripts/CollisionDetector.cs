using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.name == "rock1")
        {
            Debug.Log("Cabum");
        }
    }
}
