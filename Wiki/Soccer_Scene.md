# Soccer

## Overview

This tutorial will expand upon the Roll-A_Ball exercise by modifying a few scripts from the project to make a new game. The game will have the users move their player around the field to move the ball into their goal. The game will continue until the Victory Score is reached.

## Requirements

- Unity 3D
- Visual Studio 2015 (or later)

## Creating The Environment

1. Using the same project as Roll-A-Ball, create another scene and name it "Soccer".

2. Make a plane at origin, and change the X and Z scale to "2". Name this object "Field". Place a green material on the object.

3. Make two more planes and place them on the positive and negative side of the "field" object's X axis. Name one "RedGoal" and the other one "BlueGoal". Place a red material on "RedGoal" and a blue material on the "BlueGoal".

4. Change the RedGoal and the BlueGoals' scale to 0.5 in the X.

5. Create a cube object and change the scale on the X axis to 20. Then line it up to the "Field" object's positive Z axis side. Name it "Wall 1"

6. Duplicate "Wall 1" and move it to the "Field" object's negative Z axis side. Name it "Wall 2"

7. Next, we will fill in the rest of the gaps. So lets create another cube and change its scal on the X axis to 5. Place it on the side of the "RedGoal"'s positive Z axis. Name it "Wall 3"

8. Duplicate "Wall 3" and place it on the side of the "RedGoal"'s negative Z axis. 

9. Repeat that process for the "BlueGoal".

10. Set up your camera coordinates to where you can view the the environment from the side and at an angle. Be sure to position it to wher the "RedGoal" is on the right and the "BlueGoal" is on the left.

### Completed Environment


![alt text](https://raw.githubusercontent.com/lukeplaisance/SummerCampProjects/master/Wiki/Field2.PNG)

## Setting Up the Players and the Ball

Now that we have the environment, we need to add the functionality of the game. We can start by creating the player characters and the ball.

1. Create a Capsule and place it about 10 units in front of the "BlueGoal". Place a blue material on the capsule and name the object "Player 1".

2. On "Player 1", add a Rigidbody, and add the "PlayerMovement" script from the Roll-A-Ball project.

3. Repeat this process for "Player 2". Player 2 will have a red material on it and will be in front of the "RedGoal".

4. Create a Sphere object and place it in the middle of the "Field" object. It should be in between the two players.

## Mapping Player Inputs

1. Now that we have our players and the ball, we need a way for both of the players to move separately from one another. The way the "PlayerMovement" is set up right now, it is only supported for one input.

We are going to add two new strings named "horizontalAxis" and "verticalAxis". We will plug these in where we would add our argument for the "GetAxis" method. We are doing this becaise we will need to assign a specific axis in the inspector for each player.

```C#

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speed;

    //We are adding these two strings
    public string horizontalAxis;
    public string verticalAxis;


	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //old
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        //new
        float horizontal = Input.GetAxis(horizontalAxis);
        float vertical = Input.GetAxis(verticalAxis);

        rigidbody.AddForce(new Vector3(horizontal, 0, vertical) * speed);
	}
}
```

2. Go into the projects setting and find the "Input" tab. We will be modifying the existing "Horizontal" and "Vertical" inputs. There should be two horizontals and two verticals already there. If not, we will add them. We will first start by changing the names of the axis we will use for "Player 1". Rename these to "Horizontal1" and "Vertical1". Then do the same thing for "Player 2".

3. Inside each of these inputs are where you can map the keys. Inside of "Horizontal1" map the negative button to "a" and the positive button to "d" if it wasn't already. Then, take out the alternate positive and negative button mappings.

4. Set the gravity to "3", the dead to "0.001", and the sensitivity to "3"

5. Check off the "Snap" checkbox and uncheck the "Invert" checkbox.

6. Make sure the "Type" is set to "Key or Mouse Button" and that the Aixs is set to "X axis"

7. We will repeat this process for the "Vertical1" Axis. The only differences is that the negative button will be set to the "s" key and the position button is set to the "w" key. Then set the Axis to the "Y axis".

8. We will do the same thing for "Player 2"'s axis. The difference here is the keys we will be mapping. We will use the "left" arrow and the "right" arrow keys for Horizontal2. Then use the "up" arrow and the "down" arrow keys for Vertical2.

9. Now that we have the Axis mapped and the script modified, we can now assign those axis to their player. Go to "Player 1" in the hierarchy and look at the "PlayerMovement" script. Type "Horizontal1" in the Horizontal text box and type, "Vertical1" in the Vertical text box. We will do the same for "Player 2", but instead type "Horizontal2" and "Vertical2" in its text boxes.

With these mapped out, you should be able to move the players separately on one keyboard.

![alt text](https://raw.githubusercontent.com/lukeplaisance/SummerCampProjects/master/Wiki/control_mapping.gif)

## Setting Up Scoring

1. With Roll_A-Ball, we made a script that would add to our when we pick up an object. With soccer, we will set it up the same way, but with a few tweaks. We won't be modifying the original script, but instead, we will make a copy of the "ScoreKeeper" script and name it "SoccerScoreKeeper".

```C#

public class SoccerScoreKeeper : MonoBehaviour
{
    public int Score;
    public int VictoryScore;
    public Text ScoreVisual;
    public Text VictoryDisplay;

    //added new game object
    public GameObject ball;

    //new UnityEvent for when you make a goal
    public UnityEvent after_goal_response;

	
    private void OnTriggerEnter(Collider other)
    {
        //We won't be relying on PickUpBehaviour, so everything with the
        //score will be in here
        if(other.CompareTag("Ball"))
        {
            Score++;
            ScoreVisual.text = "Score: " + Score;
            if (Score >= VictoryScore)
            {
                VictoryDisplay.gameObject.SetActive(true);
            }
            //turns ball object off and invokes unity event
            ball.gameObject.SetActive(false);
            after_goal_response.Invoke();
        }
    }
}
```

2. Attach this script to each of the goals.

3. Create a new Canvas and name it "ScoreCanvas". Inside it, create four text objects. Two are name "RedGoalScore" and "BlueGoalScore" that are used to keep count of each player's score. The other two are name "RedVictoryDisplay" and "BlueVictoryDisplay" which are used when one of the player reached the victory score. Make sure the "RedVictoryDisplay" and "BlueVictoryDisplay" objects are turned off.

4. Move The "RedScoreDisplay" to the top right corner of the canvas and type "Score: " in the text box. Then change to color of the text to red.

5. Repeat step number 4 for the "BlueScoreDisplay", but move the object to the top right corner and change the color of the text to blue.

6. Go into the RedGoal object and look at the "SoccerScoreBehaviour. Assign the Score Visual to the "BlueGoalScore" text object and assign the Victory Display to the "BlueVictoryDisplay" text object. Assign the Ball object to the ball. Then, set the Victory Score to 3.

7. Repeat the process for the BlueGoal, but instead assign the Score Visual and Victory Display to the Red Score and Victory Display.

## Staring A New Round

1. Create three empty game objects. Name them "Player 1 Spawn", "Player 2 Spawn", and "Ball Spawn". Place these objects in the same coordinates as their actual objects. We will use these transform to respawn the players and the ball when we start a new round.

2. Create an empty game object and name it "RoundController". 

3. Create and new script and name it "NewRoundBehaviour".

```C#

public class NewRoundBehaviour : MonoBehaviour
{
    public Transform ball_spawn;
    public GameObject ball;

    public GameObject player1;
    public GameObject player2;
    public Transform player1_spawn;
    public Transform player2_spawn;


    public void StartNewRound()
    {
        ball.gameObject.SetActive(true);
        var ball_rb = ball.gameObject.GetComponent<Rigidbody>();
        ball_rb.velocity = new Vector3(0, -1, 0);
        ball_rb.freezeRotation = true;

        ball.transform.position = ball_spawn.transform.position;

        player1.transform.position = player1_spawn.transform.position;
        player2.transform.position = player2_spawn.transform.position;

        ball_rb.freezeRotation = false;
    }

    public void StopPlayerVelocity()
    {
        var player1_rb = player1.gameObject.GetComponent<Rigidbody>();
        var player2_rb = player2.gameObject.GetComponent<Rigidbody>();

        player1_rb.velocity = new Vector3(0, -1, 0);
        player2_rb.velocity = new Vector3(0, -1, 0);
    }
}
```

4. Attach this script to the "RoundController" object and assign object to their places.

5. We can go back into our RedGoal and BlueGoal objects and we will add function call in our "after_goal_response". First, call "StartNewRound" and then "StopPlayerVelocity" in the UnityEvent.