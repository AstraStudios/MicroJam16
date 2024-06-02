using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualOrTemporaryActivation : MonoBehaviour
{
    // gate is the object that will be moved, doesnt actually have to be a gate
    [SerializeField] Gate gate;
    [SerializeField] DualOrTemporaryActivation otherButton;

    [SerializeField] string activatorTag = "Dude";

    public bool pressed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == activatorTag)
        {
            pressed = true;

            gate.Open();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == activatorTag)
        {
            pressed = false;

            // only close if this is the last button released
            if (!otherButton.pressed)
                gate.Close();
        }
    }
}
