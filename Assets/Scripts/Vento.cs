using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Vento : MonoBehaviour
{
    // Start is called before the first frame update
    private float time;
    public float angle;
    public GameObject player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Inverse(player.transform.rotation);
    }
}
