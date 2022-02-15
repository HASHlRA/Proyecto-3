using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Para que la repetición del fondo funcione, se requiere la componente Moveleft
[RequireComponent(typeof(MoveLeft))]
public class RepeatBackGround : MonoBehaviour
{
    private Vector3 startPosition;
    public float repeatWidht;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatWidht = GetComponent<BoxCollider>().size.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition.x - repeatWidht)
        {
            transform.position = startPosition;
        }
    }
}
