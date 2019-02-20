using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    //bottom half of the screen, not in camera view and will not appear in the Inspector, NOTE the static
    public static float bottomY = -20f;

    // Update is called once per frame
    void Update()
    {
        //Destroy the apples when they go off screen
        if (transform.position.y > bottomY)
        {
            Destroy(this.gameObject); //destroys the gameobject this script is attached too ie the Apple
        }
    }
}
