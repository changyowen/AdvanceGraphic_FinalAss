using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ProfileData
{
    [Header("Profile")]
    public string name, introduction, phone, address, email;

    [Header("Biography")]
    public string age, IC, DOB, gender, marital, nationality, language, education, strength, objective, hobby;

    [Header("Skills")]
    public string experience, skills;

    public ProfileData (DataStoreLoad data)
    {
        name = data.profileText[0].text;
        introduction = data.profileText[1].text;
        phone = data.profileText[2].text;
        address = data.profileText[3].text;
        email = data.profileText[4].text;

        age = data.biographyText[0].text;
        IC = data.biographyText[1].text;
        DOB = data.biographyText[2].text;
        gender = data.biographyText[3].text;
        marital = data.biographyText[4].text;
        nationality = data.biographyText[5].text;
        language = data.biographyText[6].text;
        education = data.biographyText[7].text;
        strength = data.biographyText[8].text;
        objective = data.biographyText[9].text;
        hobby = data.biographyText[10].text;

        experience = data.experience.text;
        skills = data.skills.text;

    }



}
