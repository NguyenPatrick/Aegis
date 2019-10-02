/*
 * Created by: Patrick Nguyen and Bryan Battershill
 * Last Modified: 17-Jan-2016
 * App Project – Gladiator of Dimensions

 * this script changes and fades scenes
*/

// https://www.youtube.com/watch?v=0HwZQt94uHQ 


using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    void Start()
    {
        // company and game logo
        if (Application.loadedLevelName == "Game Logo") 
        {
            StartCoroutine(LogoChange("Main Menu"));
        }
    }

    // chooses scene to change with an int input
    public void WhichSceneInt(int sceneToChange)
    {
        StartCoroutine(ChangeToSceneInt(sceneToChange));
   //   if (sceneToChange == 3)
   //   {
   //      Gladiator.tutorialMode = true;
   //   }
    }

    public IEnumerator ChangeToSceneInt(int scene)
    {
        float fadeTime = GameObject.Find("_Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(scene);              
    }

    // chooses scene to change with a string input
    public void WhichSceneString(string sceneToChange)
    {
        StartCoroutine(ChangeToSceneString(sceneToChange));
    }

    public IEnumerator ChangeToSceneString(string scene)
    {
        float fadeTime = GameObject.Find("_Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(scene);
    }

    // changes logo based on time
    IEnumerator LogoChange(string scene)
    {
        yield return new WaitForSeconds(3);      
        StartCoroutine(ChangeToSceneString(scene));
    }
}
