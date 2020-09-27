using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataStoreLoad : MonoBehaviour
{
    [Header("Profile")]
    public Text[] profileText = new Text[5];

    [Header("Biography")]
    public Text[] biographyText = new Text[11];

    [Header("Skills")]
    public Text experience;
    public Text skills;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveFile()
    {
        SaveLoad.SaveData(this);
        SceneManager.LoadScene("MainMenu");
    }

    public void DiscardFile()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadFile()
    {
        SceneManager.LoadScene("ProfileEdit");
        ProfileData data = SaveLoad.LoadData();

        profileText[0].text = data.name;
        profileText[1].text = data.introduction;
        profileText[2].text = data.phone;
        profileText[3].text = data.address;
        profileText[4].text = data.email;

        biographyText[0].text = data.age;
        biographyText[1].text = data.IC;
        biographyText[2].text = data.DOB;
        biographyText[3].text = data.gender;
        biographyText[4].text = data.marital;
        biographyText[5].text = data.nationality;
        biographyText[6].text = data.language;
        biographyText[7].text = data.education;
        biographyText[8].text = data.strength;
        biographyText[9].text = data.objective;
        biographyText[10].text = data.hobby;

        experience.text = data.experience;
        skills.text = data.skills;
    }
}
