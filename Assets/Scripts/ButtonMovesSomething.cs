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

    private void Awake()
    {
        gate.position = gateOrigionalTransfrom.position;
        gate.rotation = gateOrigionalTransfrom.rotation;
    }

    private void Update()
    {
        if (gateMoving)
        {
            gateMovementLerpTimer += Time.deltaTime / gateMovementSeconds;
            float smoothTime = 1f - Mathf.Pow(1 - gateMovementLerpTimer, 3);

            // finish movement
            if (gateMovementLerpTimer >= 1)
            {
                gateMoving = false;
                gateMovementLerpTimer = 1;
                smoothTime = 1f;
            }

            // move gate
            gate.position = Vector2   .Lerp(gateOrigionalTransfrom.position, gateFinalTransform.position, smoothTime);
            gate.rotation = Quaternion.Lerp(gateOrigionalTransfrom.rotation, gateFinalTransform.rotation, smoothTime);
        }
    }
}
