using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Random = UnityEngine.Random;

public class GFManager : MonoBehaviour
{
    [SerializeField] private Status _Status;

    [SerializeField] private Transform _GirlFriendSpwaner;

    public int money;

    public GameObject GirlFriend;
    // Start is called before the first frame update
    private void Start()
    {
        //_Status.GirlFriendStatuses[Random.Range(0, _Status.GirlFriendStatuses.Length)].Colors;
        //_Status.GirlFriendStatuses[0];

        float x = Random.Range(-7.5f,7.5f);
        float y = 4;
        Instantiate(GirlFriend,new Vector2 (x,y),GirlFriend.transform.rotation);
    }


}
