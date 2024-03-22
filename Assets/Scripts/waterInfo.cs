using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshFilter filter;
    void Start()
    {
        MeshFilter filter = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] vertices = filter.mesh.vertices;
    }
}
