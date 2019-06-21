using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
