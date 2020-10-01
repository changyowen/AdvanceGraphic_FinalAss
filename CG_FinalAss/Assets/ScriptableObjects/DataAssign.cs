using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataAssign : MonoBehaviour
{
    public Portfolio[] portfolio;
    public Text[] index;
    public Text[] portfolioname;
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
        for(int i = 0; i < index.Length; i++)
        {
            int num = i + 1;
            index[i].text = num + ".";
        }
        AssignSaveFileName();
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
        EventManager.TriggerEvent("refreshText");
        panel.SetActive(false);
    }

    void AssignSaveFileName()
    {
        for (int i = 0; i < portfolioname.Length; i++)
        {
            portfolioname[i].text = portfolio[i].profileText[0];

            if(portfolioname[i].text == "" || portfolioname[i].text == "Empty*" || portfolioname[i].text == "—")
            {
                portfolioname[i].text = "Empty Portfolio";
            }
            else
            {
                portfolioname[i].fontStyle = FontStyle.Bold;
            }
        }
    }
}
