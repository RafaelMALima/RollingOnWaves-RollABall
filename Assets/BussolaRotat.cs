using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BussolaRotat : MonoBehaviour
{

    public GameObject player;
    private Vector3 rotation;


    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.FromToRotation(player.transform.forward, player.GetComponent<PlayerController>().GetClosestChickenDirection() - player.transform.forward);
    }
}
