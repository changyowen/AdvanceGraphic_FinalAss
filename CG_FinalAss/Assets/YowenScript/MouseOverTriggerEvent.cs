using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class MouseOverTriggerEvent : MonoBehaviour
{
    public GameObject ButtonText, Smoke, Player;
    ParticleSystem smokeParticleSystem;
    public GameObject normalScreen, AnimateScreen;
    public GameObject PCstand, Keyboard, usedLightning;
    RainbowLightning rainbowLightning;
    public Material normalGrey, rainbowMat;
    Material[] PCmats, KeyboardMats;
    Animator TextAnimator;
    bool mouseOver = false;
    public PlayableDirector playToPc, playToFolder;
    AsyncOperation asyncOperation;

    // Start is called before the first frame update
    void Start()
    {
        TextAnimator = ButtonText.GetComponent<Animator>();
        smokeParticleSystem = Smoke.GetComponent<ParticleSystem>();
        if(PCstand != null && Keyboard != null)
        {
            PCmats = PCstand.GetComponent<Renderer>().materials;
            KeyboardMats = Keyboard.GetComponent<Renderer>().materials;
        }
        if(usedLightning != null)
        {
            rainbowLightning = usedLightning.GetComponent<RainbowLightning>();
        }
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
                        //PcScreen.material = Resources.Load("MonitorActivateScreen", typeof(Material)) as Material;
                        
                    }
                    normalScreen.SetActive(false);
                    AnimateScreen.SetActive(true);
                    if (pulsingScript_monitor != null && pulsingScript_keyboard != null)
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

                    //change pc to rainbow texture
                    PCmats[1] = rainbowMat;
                    PCstand.GetComponent<Renderer>().materials = PCmats;
                    KeyboardMats[0] = rainbowMat;
                    Keyboard.GetComponent<Renderer>().materials = KeyboardMats;

                    //change lightning to rainbow color
                    rainbowLightning.useRainbowColors = true;

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
                        //PcScreen.material = Resources.Load("MonitorrDeactivateScreen", typeof(Material)) as Material;
                    }
                    normalScreen.SetActive(true);
                    AnimateScreen.SetActive(false);

                    //change pc to normal texture
                    PCmats[1] = normalGrey;
                    PCstand.GetComponent<Renderer>().materials = PCmats;
                    KeyboardMats[0] = normalGrey;
                    Keyboard.GetComponent<Renderer>().materials = KeyboardMats;

                    //change lightning back to white color
                    rainbowLightning.useRainbowColors = false;

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

    void OnMouseDown()
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
        playToPc.Play();
        asyncOperation = SceneManager.LoadSceneAsync("ProfileEdit");
        asyncOperation.allowSceneActivation = false;
        StartCoroutine(AllowSceneChange(playToPc, 2));
    }

    void TowardViewScene()
    {
        playToFolder.Play();
        asyncOperation = SceneManager.LoadSceneAsync("ProfileReading");
        asyncOperation.allowSceneActivation = false;
        StartCoroutine(AllowSceneChange(playToFolder, 3));
    }

    IEnumerator AllowSceneChange(PlayableDirector playable, int index)
    {
        while(playable.state == PlayState.Playing)
        {
            yield return null;
        }
        OpeningManager.OpeningIndex = index;
        asyncOperation.allowSceneActivation = true;
    }
}
