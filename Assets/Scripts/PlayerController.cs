using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private float turnSpeed = 100.0f;
    private float horizontalInput;
    private float forwardInput;
    public bool isGameActive;
    private float currentPos;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        currentPos = transform.position.y;
        if (currentPos < -30)
        {
            gameManagerScript.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameActive = false;
            Debug.Log("Game Over!");
            //explosionParticle.Play();

        }
    }
}
