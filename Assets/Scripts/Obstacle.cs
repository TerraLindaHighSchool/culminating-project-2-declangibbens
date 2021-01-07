using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float currentPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position.y;
        if (currentPos < -30)
        {
            Destroy(gameObject);
            Debug.Log("HI");
        }
    }
}
