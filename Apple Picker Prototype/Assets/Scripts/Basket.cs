using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //this line enables use of GUI features

public class Basket : MonoBehaviour
{

    [Header("Set Dynamically")]
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Find a reference to the ScoreCounter GameObject, it searches the scene for this GmeObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //GEt the Text Component of that GameObject
        scoreText = scoreGO.GetComponent<Text>();
        // Set the starting number of points to 0
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //Get the current screen position of the mouse from input
        /*The screen coords start from the top left and are in 2D, thus the z value would 0*/
        Vector3 mousePos2D = Input.mousePosition;

        //The camera's position sets how far to push the mouse into 3D
        /*Th reason for taking the -ve of the camera z pos is bcase its set in game as -10 so taking the -ve of that will
        set the mousePos.z to +10 (+ve) thus making the final world point 0 on the z plane*/
        mousePos2D.z = -Camera.main.transform.position.z;
        //Convert the point from 2D screen space into game world space, see note above
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move tthe x position of this Basket to the x positon of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    /// <summary>
    /// This method is called whenever another GameObject collides with the basket, the reference as to what was hit (collision) is also passed on
    /// as an argument
    /// </summary>
    /// <param name="collision">Collision.</param>
    private void OnCollisionEnter(Collision collision)
    {
        //Find out what hit this basket
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Apple") //checks the tag of collided obj to see if its an apple then destroy its
        {
            Destroy(collidedWith);

            //SCORE
            // parse the text of the scoreText into an int
            int score = int.Parse(scoreText.text);
            //add points for catching the apple
            score += 100;
            //convert the score back to a string and display it
            scoreText.text = score.ToString();

            //Track the high score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
