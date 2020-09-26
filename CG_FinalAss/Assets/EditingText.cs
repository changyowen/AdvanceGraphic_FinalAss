using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EditingText : MonoBehaviour
{
    GameObject button;
    public GameObject panel;
    public InputField inputText;
    Text outputText;
    public Text category;
    string textcontent;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        textcontent = inputText.text;
    }

    public void openPanel()
    {
        button = EventSystem.current.currentSelectedGameObject;
        panel.SetActive(true);
        outputText = button.gameObject.GetComponentInChildren<Text>();
        Debug.Log(outputText.name);
        category.text = outputText.name.ToString();
    }

    public void saveChanges()
    {
        outputText.text = textcontent;
        panel.SetActive(false);
    }

    public void discardChanges()
    {
        panel.SetActive(false);
    }

}
