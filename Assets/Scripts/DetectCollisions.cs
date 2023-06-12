using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.tag != "Sandwich")
        {
            PlayerController.hit();
        }
        else if (other.tag == "Monster" && gameObject.tag == "Sandwich")
        {
            PlayerController.addScore(1);
            other.GetComponent<AnimalHunger>().FeedAnimal(1);
            Destroy(gameObject);
        }

    }
}