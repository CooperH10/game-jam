using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{
    public Transform player; 
    public float smoothSpeed = 0.125f; 
    public Vector3 offset; 

    void LateUpdate() 
    {
        if (player != null)
        {
            Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, -10) + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
