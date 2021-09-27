using UnityEngine;

namespace Ru1t3rl.Effects
{
    public class ShrinkOverLife : MonoBehaviour
    {
        [SerializeField] float lifeTime;
        float startTime, shrinkRate;
        bool shrinking = false;

        void LateUpdate()
        {
            if (!shrinking)
            {
                startTime = Time.time;
                shrinking = true;
            }
            else if (transform.localScale.sqrMagnitude > 0.01f)
            {
                // Time.time - startTime will return the ellapsed time
                shrinkRate = 1 - ((Time.time - startTime) / lifeTime);
                transform.localScale = new Vector3(shrinkRate, shrinkRate, shrinkRate);
            }
            else
            {
                shrinking = false;
                gameObject.SetActive(false);
            }
        }
    }
}