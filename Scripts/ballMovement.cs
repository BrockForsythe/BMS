using UnityEngine;

public class ballMovement : MonoBehaviour
{

    public Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Got here 1");
        if (collider.gameObject.tag == "Game Phase Object")
        {
            Debug.Log("got here 2");
            GameObject.FindGameObjectWithTag("Game Manager").GetComponent<gamePhaseObjects>().NextPhase();
        }
    }
}
