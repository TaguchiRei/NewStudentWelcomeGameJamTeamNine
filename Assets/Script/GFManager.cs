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
    [SerializeField] private Transform _girlFriendSpawner;
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
            var colors = _status.GirlFriendStatuses[Random.Range(0, _status.GirlFriendStatuses.Length)].Colors;
            var money = _status.GirlFriendStatuses[0];
            float x = Random.Range(-7.5f, 7.5f);
            float y = 4;
            var obj = Instantiate(GirlFriend, new Vector2(x, y), GirlFriend.transform.rotation);
            obj.GetComponent<SpriteRenderer>().color = colors;
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}

