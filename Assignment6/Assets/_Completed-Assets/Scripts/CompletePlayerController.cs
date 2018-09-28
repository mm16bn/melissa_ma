using UnityEngine;
using System.Collections;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class CompletePlayerController : MonoBehaviour {

	public float speed;				//Floating point variable to store the player's movement speed.
	public Text starsText;		    //Store a reference to the UI Text component which displays the number of stars collected.
    public Text meteorsText;        //Store a reference to the UI text component which displays the number of meteors collected.
    public Text scoreText;          //Stores a reference ot the UI text component which displays the total score.
    public Text winText;			//Store a reference to the UI Text component which will display the 'You win' message.

	private Rigidbody2D rb2d;		//Store a reference to the Rigidbody2D component required to use 2D Physics.
    private int count_1;			//Integer to store the number of pickup 1(stars) collected so far.
    private int count_2;            //Integer to store the number of pickup 2(meteors) collected so far. 
    private int score;              //Integer to store the total score where pickup 1 is 1 pont and pickup 2 5 points.

	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();

		//Initialize count of first pickup to zero.
		count_1 = 0;

        //Initialize count of second pickup to zero.
        count_2 = 0;

		//Initialze winText to a blank string since we haven't won yet at beginning.
		winText.text = "";

		//Call our SetCountText function which will update the text with the current value for count.
		SetCountText ();
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce (movement * speed);
	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive(false);
			
			//Add one to the current value of our count variable.
			count_1 = count_1 + 1;
			
			//Update the currently displayed count by calling the SetCountText function.
			SetCountText ();
		}

        if (other.gameObject.CompareTag("Pickup2"))
        {
            other.gameObject.SetActive(false);
            count_2 = count_2 + 1;
            SetCountText(); 
        }


		

	}

	//This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
	void SetCountText()
	{
        //Sets pickup1 to 1 point, and pickup2 to 2 points. 
        score = count_1 + (count_2 * 5);

        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
        starsText.text = "Stars: " + count_1.ToString ();
        meteorsText.text = "Meteors: " + count_2.ToString();
        scoreText.text = "SCORE: " + score.ToString();


		//Check if we've collected all 12 pickups. If we have...
		if (score >= 61)
			//... then set the text property of our winText object to "You win!"
			winText.text = "YAY! YOU SAVED THE PLANET!";
	}
}
