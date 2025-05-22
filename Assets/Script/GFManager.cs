using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GFManager : MonoBehaviour
{
    [SerializeField] private Status _status;
    [SerializeField] private GameManager _gameManager;
    
    public int money;

    public GameObject GirlFriend;

    private float nextSpawnTime = 0f;
    public float spawnInterval = 2f;
    // Start is called before the first frame update

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            var randomStatus = Random.Range(0, _status.GirlFriendStatuses.Length);
            var colors = _status.GirlFriendStatuses[randomStatus].Colors;
            var money = _status.GirlFriendStatuses[randomStatus].Money;
            float x = Random.Range(-7.5f, 7.5f);
            float y = 4;
            var obj = Instantiate(GirlFriend, new Vector2(x, y), GirlFriend.transform.rotation);
            obj.GetComponent<SpriteRenderer>().color = colors;
            var gfMove = obj.GetComponent<GFMove>();
            gfMove.Money = money;
            gfMove.OnGoal = (score, mag) => _gameManager.AddScore(score, mag);
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}

