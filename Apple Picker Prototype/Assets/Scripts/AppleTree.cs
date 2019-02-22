using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    [Header("Set in Inspector")]
    //Prefab for instantiating apples
    public GameObject applePrefab;

    /// Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float LeftAndRightEdge = 10f;

    // Chance that the AppleTree will change direction
    public float chanceToChangeDirections = 0.1f;

    //rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;


    // Start is called before the first frame update
    void Start()
    {
        // Dropping apples every second
        Invoke("DropApple", 2f); //wait to call this fcuntion for 2 seconds

    }

    //Create and drop an apple at the Tree location
    private void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab); //create an instance of the Apple prefab
        apple.transform.position = transform.position; //set this newly created apples postion to that of the tree
        Invoke("DropApple", secondsBetweenAppleDrops);  //We invoke this method again by calling itself again and again it has the effect of spawning 
        // apples every second (or whatever time you set it)
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position; //current positon of AppleTree
        pos.x += speed * Time.deltaTime; //a measure of the number of seconds since the last frame, ensures smooth movement based on the fps
        //assigns the modified postion back to the position
        transform.position = pos;

        // Change Direction
        if (pos.x < -LeftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right +ve if a small value
        }
        else if (pos.x > LeftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //left -Ve if a large value
        }
    }

    private void FixedUpdate()
    {
        //only called 50 times per second and now changing direction is time based, so this has the potential to change direction once every second (50 * 0.02 = 1 second)
        // rememeber it depdens on the random value
    if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //change direction
        }
    }
}
