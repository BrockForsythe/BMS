using System.Collections;
using UnityEngine;

public class ballControl : MonoBehaviour
{
    //ball clone
    private GameObject ball;

    //ball objects and movement
    public GameObject ballPrefab;

    //ball features; boundries, despawns, timers, spawning management
    private float boundryDistance = 10f;
    private float despawnTimer = 3f;
    private float despawnSensitivity = .3f;
    private bool ticking;
    private bool spawned;


    private void Awake()
    {
        Spawn();
    }

    void Update()
    {
        //Debug.Log(ball.transform.position);
        //CheckBoundries();
        InactivityCheck();
        if (!spawned)
        {
            Spawn();
        }
    }

    private void InactivityCheck()
    {
        if (GameObject.FindWithTag("Ball").GetComponent<Rigidbody>().velocity.magnitude > despawnSensitivity)
        {
            if (!ticking) //if clock isnt running starts it
            {
                StartCoroutine(InactivityTimer());
            }
        }
        else //object is moving
        {
            ticking = false;
            StopAllCoroutines();
        }
    }

    IEnumerator InactivityTimer()
    {
        ticking = true;
        var instruction = new WaitForEndOfFrame();
        float time = despawnTimer;

        //waits for despawnTimer
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return instruction;
        }

        //timer ends
        ticking = false;
        Despawn();
    }

    private void CheckBoundries()
    {
        float dist = Vector3.Distance(transform.position, GameObject.FindWithTag("Ball").transform.position);
        if (dist > boundryDistance)
        {
            Despawn();
        }
    }

    public void Spawn()
    {
        Instantiate(ballPrefab, transform.position, Quaternion.identity);
        spawned = true;
    }

    public void Despawn()
    {
        Destroy(GameObject.FindWithTag("Ball"));
        spawned = false;
    }
}