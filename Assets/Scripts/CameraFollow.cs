using UnityEngine;

public class CameraFollow : MonoBehaviour
{ 
    public Transform player;
    void LateUpdate()
    {
        transform.position = player.position + new Vector3(0, 5, -8);
    }
}