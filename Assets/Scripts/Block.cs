using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] LayerMask ballLayer;

    private void OnCollisionEnter(Collision collision)
    {
        if(1<<collision.gameObject.layer == ballLayer)
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            if(ball != null)
            {
                ball.direction.y = -1 * ball.direction.y;
            }
        }
    }
}
