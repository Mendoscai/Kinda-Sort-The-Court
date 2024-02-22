using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Consequence
{
    public string statName;
    public int value;
}

[System.Serializable]
public class Sentence
{
    [TextArea(3, 10)]
    public string text;
    public List<Consequence> yesConsequences;
    public List<Consequence> noConsequences;
}

[System.Serializable]
public class Dialogue
{
    public string name;
    public Sprite avatar;
    public List<Sentence> sentences;
}



