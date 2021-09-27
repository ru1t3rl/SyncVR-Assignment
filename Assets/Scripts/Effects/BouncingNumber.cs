using UnityEngine;

namespace Ru1t3rl.Effects
{
    public class BouncingNumber : MonoBehaviour
    {
        Vector2 canvasSize;

        [SerializeField] float speed = 1;
        Vector3 direction;

        void Awake()
        {
            RectTransform canvasTrans = transform.GetComponentInChildren<RectTransform>();
            if (canvasTrans != null)
            {
                canvasSize.x = canvasTrans.rect.width;
                canvasSize.y = canvasTrans.rect.height;
            }
            else
            {
                canvasSize.x = Screen.width;
                canvasSize.y = Screen.height;
            }

            direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        }

        // Collision detection with the edges of the canvas
        void FixedUpdate()
        {
            transform.position += direction * speed;

            if (transform.localPosition.x <= -canvasSize.x / 2 ||
                transform.localPosition.x >= canvasSize.x / 2)
                direction.x *= -1;
            if (transform.localPosition.y <= -canvasSize.y / 2 ||
                transform.localPosition.y >= canvasSize.y / 2)
                direction.y *= -1;
        }
    }
}