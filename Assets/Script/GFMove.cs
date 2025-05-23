using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
=======
using UnityEngine.UI;
using Random = UnityEngine.Random;
>>>>>>> Stashed changes

public class GFMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] Vector3 _targetPos;
<<<<<<< Updated upstream
=======
    [SerializeField] Talk[] _talkDate;


    private GameObject _targetObject;
>>>>>>> Stashed changes
    private Rigidbody2D rb;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Love"))
        {
<<<<<<< Updated upstream
        }
        if (collision.gameObject.CompareTag("Keep"))
        {
        }
        Destroy(gameObject);//このゲームオブジェクトを消滅させる
=======
            OnGoal?.Invoke(Money, 1);
            var index = Random.Range(0, _talkDate[0].talkData.Count);

            _textMesh.text = _talkDate[0].talkData[index].Talk;
        }
        if (collision.gameObject.CompareTag("Keep"))
        {
            OnGoal?.Invoke(Money, 0.5f);

            var index = Random.Range(0, _talkDate[1].talkData.Count);

            _textMesh.text = _talkDate[1].talkData[index].Talk;
        }
        if (collision.gameObject.CompareTag("break"))
        {
            OnGoal?.Invoke(Money, 0.5f);
            var index = Random.Range(0, _talkDate[2].talkData.Count);

            _textMesh.text = _talkDate[2].talkData[index].Talk;
        }
        _isGoaled = true;
        rb.velocity = Vector2.zero;
        _textBox.SetActive(true);
        Invoke(nameof(DestroyObject),1f);
        
>>>>>>> Stashed changes
    }
    void OnMouseDrag()
    {
        //マウスカーソル及びオブジェクトのスクリーン座標を取得
        Vector3 objectScreenPoint =
           new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);//スクリーン座標をワールド座標に変換

        transform.position = objectWorldPoint; //オブジェクトの座標を変更する
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
