using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Arrastra aquí el objeto del jugador desde la jerarquía
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Distancia fija de la cámara en 2D

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
