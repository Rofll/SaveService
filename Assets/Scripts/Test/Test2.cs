using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Test2
{
    public string Key { get; set; } = "some";
    public string Name = "123";
    public int hp = 10;
    private float mana = 0.35f;

    public Test test = new Test();

    public override string ToString()
    {
        return string.Format(Key + " " + Name + " " + hp + " " + mana + " " + test);
    }
}