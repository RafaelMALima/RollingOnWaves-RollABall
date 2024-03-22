using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProperties : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshFilter filter;
    public Vector3[] vertices;
    void Start()
    {
        vertices = filter.mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        vertices = filter.mesh.vertices;
    }

}
