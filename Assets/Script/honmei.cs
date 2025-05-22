using UnityEngine;

public class VelocityExample : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(-6.18f, -0.78f, 0); // 目的の位置の座標を指定

        rb.MovePosition(targetPosition); // 目的の位置に移動
    }
}
