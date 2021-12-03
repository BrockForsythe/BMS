using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            GameObject.FindGameObjectWithTag("Game Manager").GetComponent<gamePhaseObjects>().NextPhase();
        }
    }
}
