using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Talk : ScriptableObject
{
    public List<TalkData> talkData;
}

[Serializable]
public class TalkData
{
    public string Talk;
    public int Money;
}