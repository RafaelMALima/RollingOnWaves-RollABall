using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateWaterSimplified : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WaterTile;
    public GameObject Player;
    public float timeToReloadWater = 1;

    private List<Vector3> WaterTilePositions;

    void Start()
    {
        WaterTilePositions = GetWaterTilePositions();
        destroyWater();
        foreach (Vector3 position in WaterTilePositions)
        {
            Instantiate(WaterTile, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeToReloadWater -= Time.deltaTime;

        if (timeToReloadWater <= 0.0f)
        {
            timeToReloadWater = 10;
            WaterTilePositions = GetWaterTilePositions();
            destroyWater();
            foreach (Vector3 position in WaterTilePositions)
            {
                Instantiate(WaterTile, position, Quaternion.identity);
            }
        }

    }
    List<Vector3> GetWaterTilePositions()
    {
        Vector3 playerPos = Player.transform.position;
        Vector3 playerPosRounded = new Vector3(0, 0, 0);
        playerPosRounded.x = ((int)(playerPos.x / 10)) * 10;
        playerPosRounded.y = ((int)(playerPos.y / 10)) * 10;
        playerPosRounded.z = ((int)(playerPos.z / 10)) * 10;
        List<Vector3> positions = new List<Vector3>();
        for (int i = (int)playerPosRounded.x-10; i < (int)playerPosRounded.x + 100; i+= 10)
        {
            for (int j = (int)playerPosRounded.z-50; j < (int)playerPosRounded.z + 50; j+= 10)
            {
                positions.Add(new Vector3(
                        i,
                        0,
                        j
                    ));
            }

        }

        return positions;
    }
    void destroyWater()
    {
        GameObject[] allObjects = (GameObject[])FindObjectsOfType(typeof(GameObject));
        foreach (GameObject obj in allObjects)
        {
            if (obj.transform.name == "WaterPlanePrefab(Clone)")
            {
                Destroy(obj);
            }
        }
    }

}
