using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingNumber : MonoBehaviour
{
    [SerializeField] float speed = 1;
    Vector3 direction;

    void Awake()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1), 0).normalized;
    }

    void FixedUpdate()
    {
        transform.position += direction * speed;

        // Collision detection with the edges of the Screen
        if (transform.localPosition.x <= -Screen.width / 2 ||
            transform.localPosition.x >= Screen.width / 2)
            direction.x *= -1;
        if (transform.localPosition.y <= -Screen.height / 2 ||
            transform.localPosition.y >= Screen.width / 2)
            direction.y *= -1;
    }
}
