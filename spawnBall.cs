using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBall : MonoBehaviour
{
    private GameObject ball; //what the script is attached to
    //can input starting positions
    public Vector3 startPosition;
    public Quaternion startRotation;

    private void Start()
    {
        //ball = Instantiate(this.gameObject, new Vector3(xpos, ypos, zpos), Quaternion.identity);
        ball = this.gameObject;
        ball.SetActive(false);
    }
    public void SpawnBall()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        ball.SetActive(true);
    }

    public void DespawnBall()
    {
        ball.SetActive(false);
    }

    public void RespawnBall()
    {
        if (ball.activeSelf) //if ball exists
        {
            DespawnBall(); //despawn ball first
        }
        SpawnBall(); //spawn ball
    }

}
