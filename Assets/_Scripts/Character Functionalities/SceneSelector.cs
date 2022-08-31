using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelector : MonoBehaviour
{

    // Singleton
    private SceneSelector Instance;

    public OVRScreenFade Fader;

    // Buttons from the scene selector canvas
    public Button A;
    public Button B;
    public Button C;
    // the active scene
    private int activeScene;

    // Start is called before the first frame update
    void Start()
    {
        //singleton check
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
            activeScene = 0;

            if(A && B && C){
                A.onClick.AddListener(delegate{ StartCoroutine(setScene(0)); });
                B.onClick.AddListener(delegate{ StartCoroutine(setScene(1)) ; });
                C.onClick.AddListener(delegate{ StartCoroutine(setScene(2)); });
            }
            Fader.FadeIn();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator setScene(int ss){
        // check if the scene is changing
       // if(activeScene!=ss){
            activeScene = ss;

            //checked if scene is int range of available scenes
            if(ss < 3 && ss >=0){

                string Scene;

                // switch
                if(ss==0){
                    Scene = "Pre-Production_Graphics";
                }else if(ss==1){
                    Scene = "Pre-Production_Refuge Chamber";
                }else {
                    Scene = "Pre-Production_Waiting Area";
                }

                // change scene
                activeScene = ss;
                yield return Fader.Fade(0f,1f);
                SceneManager.LoadScene(Scene);

                yield return null;
            }
       // }

    }

}
