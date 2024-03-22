using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class floater : MonoBehaviour
{
    public Rigidbody body;

    public float depthSubmerged;
    public float displacementAmount;
    public float linearDrag = 0.99f;
    public float angularDrag = 0.5f;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.AddForceAtPosition( Physics.gravity / 4, transform.position, ForceMode.Acceleration);
        float height = GetHeightAt(transform.position.x, transform.position.z);
        if (transform.position.y < height)
        {
            float displacementMultiplier = Mathf.Clamp01((height - transform.position.y) * displacementAmount);
            body.AddForceAtPosition( new Vector3(0, Mathf.Abs(Physics.gravity.y/ 2) * displacementMultiplier, 0), transform.position, ForceMode.Acceleration);
            body.AddForce(displacementMultiplier * -body.velocity * linearDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            body.AddTorque(displacementMultiplier * -body.angularVelocity * angularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        time += Time.fixedDeltaTime;
    }

    private float GetHeightAt(float x_p, float y_p)
    {
        float x = 0.4f * time * 0.7f + x_p;
        float y = 0.4f * time * 0.3f + y_p;
        float h = Mathf.Sin(x) + Mathf.Sin(y);
        return h/8;
    }
}
