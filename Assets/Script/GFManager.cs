using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Random = UnityEngine.Random;

public class GFManager : MonoBehaviour
{
    [SerializeField] private Status _Status;
    [SerializeField] private Transform _GirlFriendSpawner;

    public int money;

    public GameObject GirlFriend;

    private float nextSpawnTime = 0f;
    public float spawnInterval = 2f;
    // Start is called before the first frame update

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            var colors = _Status.GirlFriendStatuses[Random.Range(0, _Status.GirlFriendStatuses.Length)].Colors;
            var money = _Status.GirlFriendStatuses[0];
            float x = Random.Range(-7.5f, 7.5f);
            float y = 4;
            var obj = Instantiate(GirlFriend, new Vector2(x, y), GirlFriend.transform.rotation);
            obj.GetComponent<SpriteRenderer>().color = colors;
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}

