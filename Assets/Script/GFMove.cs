using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GFMove : MonoBehaviour
{
    [SerializeField] GameObject _textBox;
    [SerializeField] TextMesh _textMesh;
    [SerializeField] private float speed = 5f;
    [SerializeField] Vector3 _targetPos;
    [SerializeField] Talk[] _talkDate;

    private GameObject _targetObject;
    private Rigidbody2D rb;

    bool _mouseClick ;
    private bool _isGoaled;

    public int Money;
    public int  GFIndex;
    public Action<float, float> OnGoal;
    public Action<int> CheckLegacy;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _targetObject = GameObject.FindGameObjectWithTag("Love");
    }
    void FixedUpdate()
    {
        if (_isGoaled) return;
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
        if(_isGoaled) return;
        if (collision.gameObject.CompareTag("Love"))
        {
            OnGoal?.Invoke(Money, 1);
            var index = Random.Range(0, _talkDate[0].talkData.Count);
            _textMesh.text = _talkDate[0].talkData[index].Talk;
            CheckLegacy?.Invoke(GFIndex);
        }
        if (collision.gameObject.CompareTag("Keep"))
        {
            OnGoal?.Invoke(Money, 0.5f);
            var index = Random.Range(0, _talkDate[1].talkData.Count);
            _textMesh.text = _talkDate[1].talkData[index].Talk;
            CheckLegacy?.Invoke(GFIndex);
        }
        if (collision.gameObject.CompareTag("brake"))
        {
            OnGoal?.Invoke(Money, 0.5f);
            var index = Random.Range(0, _talkDate[2].talkData.Count);
            _textMesh.text = _talkDate[2].talkData[index].Talk;
        }
        _isGoaled = true;
        rb.velocity = Vector2.zero;
        _textBox.SetActive(true);
        Invoke(nameof(DestroyObject),1f);
    }
    void OnMouseDrag()
    {
        if (_isGoaled) return;
        Vector3 objectScreenPoint =
           new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);//?X?N???[?????W?????[???h???W????

        transform.position = objectWorldPoint; //?I?u?W?F?N?g????W???X????
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
