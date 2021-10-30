using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    private GameObject ball; //assigns object to script
    private Rigidbody rb; //gets the rigidbody of the object

    //for despawning stationary ball
    private bool ticking;
    private Coroutine run;
    public float despawn_timer = 5f; //how fast it despawns (in seconds)

    // Start is called before the first frame update
    void Start()
    {
        ball = this.gameObject;
        rb = GetComponent<Rigidbody>();
    }

    //update runs every frame
    void Update()
    {
        InactivityCheck();
    }

    //checks if the ball hasnt been moving
    private void InactivityCheck()
    {
        if (rb.IsSleeping()) //checks if object is stationary
        {
            if (!ticking) //if clock isnt running starts it
            {
                run = StartCoroutine(InactiveTimer(despawn_timer));
                Debug.Log("Timer Started");
            }
        }
        else //object is moving
        {
            if (ticking) //if clock is running, stops it
            {
                StopCoroutine(run);
                ticking = false;
                Debug.Log("Timer Stopped");
            }
        }
    }

    //clocks for calculating inactivity
    IEnumerator InactiveTimer(float time)
    {
        ticking = true;
        var instruction = new WaitForEndOfFrame();
        
        while (time > 0)
        {
            time -= Time.deltaTime;
            Debug.Log("Time = " + time);
            yield return instruction;
        }
        ticking = false;
        Despawn();
    }

    //simple "despawn" setting activity to false
    public void Despawn()
    {
        ball.SetActive(false);
    }
}