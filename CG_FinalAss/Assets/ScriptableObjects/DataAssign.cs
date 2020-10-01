using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataAssign : MonoBehaviour
{
    public Portfolio[] portfolio;
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
        //index.text = portfolio.indexnumber.ToString();
        //portfolioname.text = portfolio.profileText[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveFile(int index)
    {
        for(int i = 0; i < 5; i++)
        {
            portfolio[index].profileText[i] = profileText[i].text;
        }
        for(int i = 0; i < 11; i++)
        {
            portfolio[index].biographyText[i] = biographyText[i].text;
        }
        portfolio[index].experience = experience.text;
        portfolio[index].skills = skills.text;
        EditorUtility.SetDirty(portfolio[index]);
        OpeningManager.OpeningIndex = 2;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadFile(int index)
    {
        for(int i = 0; i < 5; i++)
        {
            profileText[i].text = "" + portfolio[index].profileText[i];
        }
        for (int i = 0; i < 11; i++)
        {
            biographyText[i].text = "" + portfolio[index].biographyText[i];
        }
        experience.text = "" + portfolio[index].experience;
        skills.text = "" + portfolio[index].skills;
        panel.SetActive(false);
    }
}
