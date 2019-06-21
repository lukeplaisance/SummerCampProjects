using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ScoreKeeper>())
        {
            other.GetComponent<ScoreKeeper>().Score++;
            Destroy(this.gameObject);
        }
    }
}
