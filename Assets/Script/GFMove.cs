using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFMove : MonoBehaviour
{
    [SerializeField] GameObject _textBox;
    [SerializeField] TextMesh _textMesh;
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
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
    
        
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Love"))
        {
        }
        if (collision.gameObject.CompareTag("Keep"))
        {
        }
        _textBox.SetActive(true);
        Invoke(nameof(DestroyObject),1f);
    }
}
