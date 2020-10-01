using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
    public GameObject biography, biographyPanel;
    public GameObject skills, skillsPanel;
    public GameObject saveloadpanel;
    public GameObject saveButton, discardButton;

    // Start is called before the first frame update
    void Start()
    {
        biographyPanel.SetActive(false);
        skillsPanel.SetActive(false);
        saveloadpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBiography()
    {
        biography.SetActive(false);
        skills.SetActive(false);
        biographyPanel.SetActive(true);
        saveButton.SetActive(false);
        discardButton.SetActive(false);
    }

    public void CloseBiography()
    {
        biography.SetActive(true);
        skills.SetActive(true);
        biographyPanel.SetActive(false);
        saveButton.SetActive(true);
        discardButton.SetActive(true);
    }

    public void OpenSkills()
    {
        biography.SetActive(false);
        skills.SetActive(false);
        skillsPanel.SetActive(true);
        saveButton.SetActive(false);
        discardButton.SetActive(false);
    }

    public void CloseSkills()
    {
        biography.SetActive(true);
        skills.SetActive(true);
        skillsPanel.SetActive(false);
        saveButton.SetActive(true);
        discardButton.SetActive(true);
    }

    public void saveload()
    {
        saveloadpanel.SetActive(true);
    }
}
