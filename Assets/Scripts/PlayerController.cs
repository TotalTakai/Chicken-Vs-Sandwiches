using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float playerSpeed = 10.0f;
    public float boundaryXPosition = 14.0f;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * playerSpeed * Time.deltaTime);
        CheckBoundary();
        LaunchProjectile();
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
    }

    //Launches the player projectile
    void LaunchProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
