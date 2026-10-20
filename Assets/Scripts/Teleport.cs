using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Posición a la que se teletransportará el jugador
    public Vector2 teleportPosition;

    // Referencia al jugador (arrastrar desde el Inspector)
    public GameObject player;

    // Detecta cuando algo entra en el collider (asegúrate que el collider esté como "Is Trigger")
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            // Teletransporta al jugador a la posición deseada
            player.transform.position = teleportPosition;
        }
    }
}
