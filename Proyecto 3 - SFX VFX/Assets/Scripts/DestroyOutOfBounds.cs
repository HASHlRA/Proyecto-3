using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float xLim = -10f;

    // Update is called once per frame
    void Update()
    {
        // Obst�culo esquivado
        if (transform.position.x > xLim)
        {
            Destroy(gameObject);
        }
    }
}
