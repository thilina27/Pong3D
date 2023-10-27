using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private bool isPlayerOne;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask ballLayer;


    private Rigidbody rb;
    private Vector3 directoin;
    private Ball ball;

    public bool IsEnabled;
    public bool IsAI;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        directoin = Vector3.zero;
        IsEnabled = false;
    }
    private void Start()
    {
        ball = FindAnyObjectByType<Ball>();
    }

    private void Update()
    {
        directoin = Vector3.zero;
        if (!IsEnabled)
        {
            return;
        }
        if (isPlayerOne)
        {
            if(Input.GetKey(KeyCode.W))
            {
                directoin = new Vector3(0, 1, 0);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                directoin = new Vector3(0, -1, 0);
            }
        }
        else if(!isPlayerOne && !IsAI)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                directoin = new Vector3(0, 1, 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                directoin = new Vector3(0, -1, 0);
            }
        }
        else if (IsAI)
        {
            directoin = new Vector3(0, GetYDirection(this.transform.position), 0);
        }
    }

    private void FixedUpdate()
    {
        if (IsEnabled)
        {
            rb.velocity = directoin * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if( 1<<collision.gameObject.layer == ballLayer)
        {
            ball.direction.x = -1 * ball.direction.x;
            if(IsAI)
            {
                ball.direction.y = -1 * ball.direction.y;
            }
            else
            {
                ball.direction.y = this.directoin.y;
            }
            ball.collisionCount++;
        }
    }

    public float GetYDirection(Vector3 currentPos)
    {
        float yDir = 0;
        float d = ball.transform.position.y - currentPos.y;
        if (d > 0)
        {
            yDir = Mathf.Min(d, 1f);
        }
        if (d < 0)
        {
            yDir = Mathf.Min(d, 1f);
        }

        return yDir;
    }
}
