using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseOverTriggerEvent : MonoBehaviour
{
    public GameObject ButtonText, Smoke, Player;
    ParticleSystem smokeParticleSystem;
    Animator TextAnimator;
    bool mouseOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        TextAnimator = ButtonText.GetComponent<Animator>();
        smokeParticleSystem = Smoke.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        TextAnimator.SetBool("OnMouseOver", mouseOver);
    }

    void OnMouseOver()
    {
        switch(this.gameObject.tag)
        {
            case "CreatePortfolio":
                {
                    mouseOver = true;

                    Renderer PcScreen = transform.GetChild(0).gameObject.GetComponent<Renderer>();
                    PulsingScript pulsingScript_monitor = this.gameObject.GetComponent<PulsingScript>();
                    PulsingScript pulsingScript_keyboard = this.gameObject.transform.parent.transform.GetChild(1).gameObject.GetComponent<PulsingScript>();
                    if (PcScreen != null)
                    {
                        PcScreen.material = Resources.Load("MonitorActivateScreen", typeof(Material)) as Material;
                    }
                    if(pulsingScript_monitor != null && pulsingScript_keyboard != null)
                    {
                        if (pulsingScript_monitor.coroutineAllowed)
                        {
                            StartCoroutine(pulsingScript_monitor.StartPulsing());
                        }
                        if (pulsingScript_keyboard.coroutineAllowed)
                        {
                            StartCoroutine(pulsingScript_keyboard.StartPulsing());
                        }
                    }
                    break;
                }
            case "ViewPortfolio":
                {
                    if(!smokeParticleSystem.isPlaying)
                    {
                        smokeParticleSystem.Play();
                    }
                    var emission = smokeParticleSystem.emission;
                    emission.enabled = true;

                    Outline outline = this.gameObject.GetComponent<Outline>();
                    PulsingScript pulsingScript = this.gameObject.transform.parent.gameObject.GetComponent<PulsingScript>();
                    if(outline != null)
                    {
                        outline.enabled = true;
                    }
                    if (pulsingScript != null)
                    {
                        if(pulsingScript.coroutineAllowed)
                        {
                            StartCoroutine(pulsingScript.StartPulsing());
                        }
                    }
                    mouseOver = true;
                    break;
                }
        }
    }

    void OnMouseExit()
    {
        switch (this.gameObject.tag)
        {
            case "CreatePortfolio":
                {
                    mouseOver = false;

                    Renderer PcScreen = transform.GetChild(0).gameObject.GetComponent<Renderer>();
                    if (PcScreen != null)
                    {
                        PcScreen.material = Resources.Load("MonitorrDeactivateScreen", typeof(Material)) as Material;
                    }
                    break;
                }
            case "ViewPortfolio":
                {
                    var emission = smokeParticleSystem.emission;
                    emission.enabled = false;

                    Outline outline = this.gameObject.GetComponent<Outline>();
                    if (outline != null)
                    {
                        outline.enabled = false;
                    }
                    mouseOver = false;
                    break;
                }
        }
    }

    void OnMouseEnter()
    {
        switch (this.gameObject.tag)
        {
            case "CreatePortfolio":
                {
                    TowardCreateScene();
                    break;
                }
            case "ViewPortfolio":
                {
                    TowardViewScene();
                    break;
                }
        }
    }

    void TowardCreateScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("ProfileEdit");
    }

    void TowardViewScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("ProfileReading");
    }
}
