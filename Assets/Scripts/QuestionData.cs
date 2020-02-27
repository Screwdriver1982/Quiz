using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question Data")]
public class QuestionData : ScriptableObject
{
    public Sprite image;
    public string[] questions;
    public int rightAnswer;
}
