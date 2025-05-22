using System;
using UnityEngine;

public class GFMove : MonoBehaviour
{
    [SerializeField] GameObject _textBox;
    [SerializeField] TextMesh _textMesh;
    [SerializeField] private float speed = 5f;
    [SerializeField] Vector3 _targetPos;
    private Rigidbody2D rb;

    public Action AddScore;

    bool _mouseClick ;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (!_mouseClick)
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
        AddScore?.Invoke();
        Invoke(nameof(DestroyObject),1f);
    }
    void OnMouseDrag()
    {
        //�}�E�X�J�[�\���y�уI�u�W�F�N�g�̃X�N���[�����W���擾
        Vector3 objectScreenPoint =
           new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);//�X�N���[�����W�����[���h���W�ɕϊ�

        transform.position = objectWorldPoint; //�I�u�W�F�N�g�̍��W��ύX����
    }

    private void OnMouseDown()
    {
        _mouseClick = true;
    }
    private void OnMouseUp()
    {
        _mouseClick = false;
    }
}
