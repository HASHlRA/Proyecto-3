using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;

    private float xLim = -4f;

    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            // Nos desplazamos constantemente a la izquierda
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < xLim && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
