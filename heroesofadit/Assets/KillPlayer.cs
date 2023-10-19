using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject.
    public Transform respawnPoint;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with kill object. Respawning player.");
            // Move the player to the respawn point.
            player.transform.position = respawnPoint.position;
        }
    }
}
