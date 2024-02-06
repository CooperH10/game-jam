using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f; // tracks more smoothly
    public Vector3 offset; // offset of camera

   

    void FixedUpdate() 
    {
        if (player != null)
        {
            // Idk why z = 10 or what offset is doing 
            Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, -10) + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
