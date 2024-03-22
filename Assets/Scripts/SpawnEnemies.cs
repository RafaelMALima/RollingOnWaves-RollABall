using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject enemy;
    private float time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 10)
        {
            Vector3 offset = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            Instantiate(enemy, player.transform.position + offset, Quaternion.identity);
            time = 0;
        }
    }
}
