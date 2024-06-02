using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] Transform gate;
    [SerializeField] Transform gateOrigionalTransfrom;
    [SerializeField] Transform gateFinalTransform;
    [SerializeField] float gateMovementSeconds;

    public bool open = false;
    float movementLerpTimer = 0f; // count up to one

    public void Open()
    {
        open = true;
    }

    public void Close()
    {
        open = false;
    }


    private void Awake()
    {
        gate.position = gateOrigionalTransfrom.position;
        gate.rotation = gateOrigionalTransfrom.rotation;
    }

    private void Update()
    {
        if (open)
        {
            movementLerpTimer += Time.deltaTime / gateMovementSeconds;
            float smoothTime = 1f - Mathf.Pow(1 - movementLerpTimer * .8f, 3);

            // finish movement/fix
            if (movementLerpTimer >= 1)
            {
                movementLerpTimer = 1;
                smoothTime = 1f;
            }

            // move gate
            gate.position = Vector2   .Lerp(gateOrigionalTransfrom.position, gateFinalTransform.position, smoothTime);
            gate.rotation = Quaternion.Lerp(gateOrigionalTransfrom.rotation, gateFinalTransform.rotation, smoothTime);
        }
        else 
        {
            movementLerpTimer -= Time.deltaTime / gateMovementSeconds;
            float smoothTime = 1 - Mathf.Pow(1 - movementLerpTimer * .8f, 3);

            // finish movement/fix (back at start)
            if (movementLerpTimer <= 0)
            {
                movementLerpTimer = 0f;
                smoothTime = 0f;
            }

            // move gate
            gate.position = Vector2   .Lerp(gateOrigionalTransfrom.position, gateFinalTransform.position, smoothTime);
            gate.rotation = Quaternion.Lerp(gateOrigionalTransfrom.rotation, gateFinalTransform.rotation, smoothTime);
        }
    }

    // keep it simple, stupid
}
