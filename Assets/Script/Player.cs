using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 displacement;
    [SerializeField] float gravity;
    [SerializeField] float upAcceleration;

    GameManager gameManager;

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Go back to the center of the screen
    private void OnEnable() {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        displacement = Vector3.zero;
    }

    private void Update() {
        // Handle the input
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) {
            displacement = Vector3.up * upAcceleration;
        } else if (Input.GetKeyDown(KeyCode.M)) {
            gameManager.Mute();
        } else if (Input.GetKeyDown(KeyCode.LeftShift)) {
            gameManager.Pause();
        }
        
        // Player should always dropping
        displacement.y += gravity * Time.deltaTime;
        // Update the position
        transform.position += displacement * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Obstacle")) {
            gameManager.GameOver();
        } else if(other.CompareTag("Point")) {
            Debug.Log("Player get 1 score!");
            gameManager.IncreaseScore();
        }
    }
}
