using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Test
{
    public string Key { get; set; } = "some";

    public string Name = "123";
    public int hp = 10;

    public override string ToString()
    {
        return string.Format(Key + " " + Name + " " + hp);
    }
}