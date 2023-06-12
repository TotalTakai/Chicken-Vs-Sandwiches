using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float playerSpeed = 10.0f;
    public float boundaryXPosition = 14.0f;
    private float lowerBoundaryZPosition = -0.5f;
    private float higherBondaryZPosition = 15.5f;
    public GameObject projectilePrefab;
    static int score = 0;
    static int playerLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        LaunchProjectile();
    }

    // Controls the player Vertical and Horizontal Movment
    void PlayerMovement()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * verticalInput * playerSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * playerSpeed * Time.deltaTime);
        CheckBoundary();
    }
    // Make sure the player is in boundary
    void CheckBoundary()
    {
        if(transform.position.x < -boundaryXPosition)
        {
            transform.position = new Vector3(-boundaryXPosition, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > boundaryXPosition)
        {
            transform.position = new Vector3(boundaryXPosition, transform.position.y, transform.position.z);
        }
        if(transform.position.z < lowerBoundaryZPosition)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, lowerBoundaryZPosition);
        }
        else if(transform.position.z > higherBondaryZPosition)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, higherBondaryZPosition);
        }
    }

    //Launches the player projectile
    void LaunchProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
    static public void hit()
    {
        playerLives--;
        if (playerLives > 0)
        {
            Debug.Log($"Lives: {playerLives}, Score: {score}");
        }
        else
        {
            Debug.Log("Game Over!");
        }
    }

    static public void addScore(int value)
    {
        if(playerLives > 0)
        {
            score++;
            Debug.Log($"Lives: {playerLives}, Score: {score}");
        }
    }
}
