using UnityEngine;

public class CameraFollow : MonoBehaviour
{
public Transform player;

[Header("Camera Position")]
public Vector3 offset = new Vector3(0, 6, -10);

void LateUpdate()
{
    if (player == null)
        return;

    transform.position = player.position + offset;
}

}