using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    [Header("Portal Setup")]
    public PortalTeleporter targetPortal;

    [Tooltip("How far above the target portal the player appears.")]
    public float exitOffset = 1.0f;

    [Tooltip("Minimum time before this rigidbody can be teleported again.")]
    public float teleportCooldown = 0.2f;

    private static readonly Dictionary<int, float> LastTeleportTimeByBodyId = new Dictionary<int, float>();

    private void OnTriggerEnter(Collider other)
    {
        TryTeleport(other.attachedRigidbody);
    }

    private void OnCollisionEnter(Collision collision)
    {
        TryTeleport(collision.rigidbody);
    }

    private void TryTeleport(Rigidbody body)
    {
        if (targetPortal == null || body == null)
        {
            return;
        }

        // Only teleport the player.
        if (!body.CompareTag("Player") && body.GetComponent<PlayerController>() == null)
        {
            return;
        }

        int bodyId = body.GetInstanceID();
        float lastTeleportTime;
        if (LastTeleportTimeByBodyId.TryGetValue(bodyId, out lastTeleportTime))
        {
            if (Time.time - lastTeleportTime < teleportCooldown)
            {
                return;
            }
        }

        LastTeleportTimeByBodyId[bodyId] = Time.time;

        Vector3 destination = targetPortal.transform.position + (targetPortal.transform.up * targetPortal.exitOffset);

        body.position = destination;
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
    }
}
