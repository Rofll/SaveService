using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;

[ProtoContract]
[System.Serializable]
public class Test
{
    [ProtoMember(1)]
    public string Key { get; set; } = "some";

    [ProtoMember(2)]
    public string Name = "123";
    [ProtoMember(3)]
    public int hp = 10;

    public override string ToString()
    {
        return string.Format(Key + " " + Name + " " + hp);
    }
}