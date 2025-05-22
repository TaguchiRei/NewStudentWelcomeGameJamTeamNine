using Unity.VisualScripting;
using UnityEngine;

public class VelocityExample : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] Vector3 _targetPos;
    private Rigidbody2D rb;

    bool _mouseClick = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }










    void FixedUpdate()
    {
        if (_mouseClick)
        {

            var nowPos = transform.position;

            var moveV = _targetPos - nowPos;
            moveV.Normalize();

            rb.velocity = moveV * speed;
        }
    }
}
