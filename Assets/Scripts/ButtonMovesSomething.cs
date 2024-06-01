using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovesSomething : MonoBehaviour
{
    // gate is the object that will be moved, doesnt actually have to be a gate
    [Header("Gate is the object being moved")]
    [SerializeField] Transform gate;
    [SerializeField] Transform gateOrigionalTransfrom;
    [SerializeField] Transform gateFinalTransform;

    bool gateMoving = false;
    float gateMovementLerpTimer = 0f; // count up to one
    [SerializeField] float gateMovementSeconds = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.Equals(collision.gameObject.layer, LayerMask.NameToLayer("Player")))
            gateMoving = true;
    }

    private void Update()
    {
        if (gateMoving)
        {
            gateMovementLerpTimer += Time.deltaTime / gateMovementSeconds;

            // finish movement
            if (gateMovementLerpTimer > 1)
            {
                gateMoving = false;
                gateMovementLerpTimer = 1;
            }

            // move gate
            float smoothTime = Mathf.SmoothStep(0f, 1f, gateMovementLerpTimer);
            gate.position = Vector2   .Lerp(gateOrigionalTransfrom.position, gateFinalTransform.position, smoothTime);
            gate.rotation = Quaternion.Lerp(gateOrigionalTransfrom.rotation, gateFinalTransform.rotation, smoothTime);
        }
    }
}
