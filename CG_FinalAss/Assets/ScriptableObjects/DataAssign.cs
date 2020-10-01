using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataAssign : MonoBehaviour
{
    public Portfolio portfolio;
    public Text index, portfolioname;
    public GameObject panel;

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
        index.text = portfolio.indexnumber.ToString();
        portfolioname.text = portfolio.profileText[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveFile()
    {
        for(int i = 0; i < 5; i++)
        {
            portfolio.profileText[i] = profileText[i].text;
        }
        for(int i = 0; i < 11; i++)
        {
            portfolio.biographyText[i] = biographyText[i].text;
        }
        portfolio.experience = experience.text;
        portfolio.skills = skills.text;
        OpeningManager.OpeningIndex = 2;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadFile()
    {
        for(int i = 0; i < 5; i++)
        {
            profileText[i].text = portfolio.profileText[i];
        }
        for (int i = 0; i < 11; i++)
        {
            biographyText[i].text = portfolio.biographyText[i];
        }
        experience.text = portfolio.experience;
        skills.text = portfolio.skills;
        panel.SetActive(false);
    }
}
