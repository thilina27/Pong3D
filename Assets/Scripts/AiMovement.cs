using UnityEngine;

public class AiMovement : MonoBehaviour
{
    private Manager manager;

    private void Start()
    {
        manager = Manager.Instance;
    }

    public float GetYDirection(Vector3 currentPos)
    {
        float yDir = 0;
        float d = manager.ball.direction.y - currentPos.y;
        if(d > 0)
        {
            yDir = Mathf.Min(d, 1f);
        }
        if(d < 0)
        {
            yDir = Mathf.Min(d, 1f);
        }

        return yDir;
    }
}
