using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public bool isGameActive = true;
    private float xMin = -68.5f;
    private float xMax = -45.0f;
    private float ySpawnPos = -21.25f;
    private float vehiclePos;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        vehiclePos = GameObject.Find("Vehicle").transform.position.z;
        
        
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index], RandomSpawnPos(), transform.rotation);
        }
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(xMin, xMax), ySpawnPos, vehiclePos + 165);
    }
}
