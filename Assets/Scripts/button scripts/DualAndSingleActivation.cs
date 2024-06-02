using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualSingleActivateButton : MonoBehaviour
{
    // gate is the object that will be moved, doesnt actually have to be a gate
    [SerializeField] Gate gate;
    [SerializeField] DualSingleActivateButton otherButton;

    [SerializeField] string activatorTag = "Dude";

    public bool pressed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == activatorTag)
        {
            pressed = true;

            // only activate gate if other button is pressed
            if (otherButton.pressed)
                gate.Open();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == activatorTag)
            pressed = false;
    }
}
