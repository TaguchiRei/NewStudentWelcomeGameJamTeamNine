using System;
using UnityEngine;

[CreateAssetMenu]
public class Status : ScriptableObject
{
    public GirlFriendStatus[] GirlFriendStatuses;
}

[Serializable]
public class GirlFriendStatus
{
    public Color Colors;
    public int Money;
}
