using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Portfolio", menuName = "Portfolio")]
public class Portfolio : ScriptableObject
{
    [Header("Index")]
    public int indexnumber;

    [Header("Profile")]
    public string[] profileText = new string[5];
    //name introduction phone address email

    [Header("Biography")]
    public string[] biographyText = new string[11];
    //age;IC;DOB;gender;marital;nationality;language;education;strength;objective;hobby;

    [Header("Skills")]
    public string experience;
    public string skills;
}
