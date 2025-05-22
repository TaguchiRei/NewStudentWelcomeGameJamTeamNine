using UnityEngine;

public class VelocityExample : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] Vector3 _targetPos;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        var nowPos = transform.position;

        var moveV= _targetPos - nowPos;
        moveV.Normalize();

        rb.velocity = moveV *speed;
    }
}
