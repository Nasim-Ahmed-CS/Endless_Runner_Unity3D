using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] roadPrefabs;
    public float zSpawn = 0;
    public float roadLength = 17.0547f;
    public int numberOfRoads = 5;

    public Transform playerTransform;

    private List<GameObject> _activeRoads = new List<GameObject>();

    

    void Start()
    {

       

        for(int i = 0; i < numberOfRoads; i++)
        {
            if(i == 0)
            {
                spawnRoad(i);
            }
            else
            {
                spawnRoad(Random.Range(0, roadPrefabs.Length));
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - 23 > zSpawn - (numberOfRoads * roadLength))
        {
            spawnRoad(Random.Range(0, roadPrefabs.Length));
            DeleteRoad();
        }
    }
    public void spawnRoad(int roadIndex)
    {
        
        GameObject newRoad = Instantiate(roadPrefabs[roadIndex], new Vector3(0, 0, zSpawn), transform.rotation);
        _activeRoads.Add(newRoad);
        zSpawn += roadLength;
    }
    private void DeleteRoad()
    {
        Destroy(_activeRoads[0]);
        _activeRoads.RemoveAt(0);
    }
}
