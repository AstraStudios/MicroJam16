using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougTrig : MonoBehaviour
{
    [SerializeField] Dialoug dialoug;
    [SerializeField] string activatorTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != activatorTag) return;

        dialoug.enabled = true;
        Destroy(this);
    }
}
