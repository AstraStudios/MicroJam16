using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleActivateButton : MonoBehaviour
{
    // gate is the object that will be moved, doesnt actually have to be a gate
    [SerializeField] Gate gate;

    [SerializeField] string activatorTag = "Dude";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == activatorTag)
            gate.Open();
    }
}
