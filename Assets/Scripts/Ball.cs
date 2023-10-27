using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int collisionLimit;
    [SerializeField] private float speedIncrease;

    private Rigidbody rb;
    private float currentSpeed;

    public Vector3 direction;
    public int collisionCount;
    public bool isEnabled;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = speed;
    }

    private void Update()
    {
        if(collisionCount > collisionLimit)
        {
            collisionCount = 0;
            currentSpeed += speedIncrease;
        }
    }

    private void FixedUpdate()
    {
        if(isEnabled)
        {
            rb.velocity = direction.normalized * currentSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void ResetSpeed()
    {
        currentSpeed = speed;
    }
}
