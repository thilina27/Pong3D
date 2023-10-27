using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private LayerMask ballLayer;
    [SerializeField] private bool playerOneGoal;

    private void OnCollisionEnter(Collision collision)
    {
        if(1<<collision.gameObject.layer == ballLayer)
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            if(ball != null)
            {
                ball.transform.position = new Vector3(0, 0, -1);
                ball.isEnabled = false;
                Manager.Instance.gameToReset = true;
                if(playerOneGoal)
                {
                    Manager.Instance.UpdatePlayerOneScore();
                }
                else
                {
                    Manager.Instance.UpdatePlayerTwoScore();
                }
            }
        }
    }
}
