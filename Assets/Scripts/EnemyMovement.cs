using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float omega = 0.4f;
    public float speed = 1f;
    public int damage = 20;

    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        //transform.position = new Vector3(transform.position.x, Mathf.Sin(time), transform.position.y);
        rb.velocity = transform.forward.normalized * speed;
        rb.AddTorque(new Vector3(0, omega, 0));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
