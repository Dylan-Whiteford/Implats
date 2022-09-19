using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;
using Normal.Realtime;
using System;
using UnityEngine.SceneManagement;
using Autohand;
public class Player : MonoBehaviour
{
    public static Player instance;
    private void Awake()
    {

        // check if player already exists
        if (!instance){
            instance = this;
            transform.parent = null;
            DontDestroyOnLoad(this.gameObject);
            OVRManager.fixedFoveatedRenderingLevel = OVRManager.FixedFoveatedRenderingLevel.HighTop; // it's the maximum foveation level

        }
        else
        {
            Debug.Log("There is more than one instance of Player in this scene");
            Destroy(this.gameObject);
        }

        SceneManager.sceneLoaded += sceneLoader;


    }

    private void sceneLoader(Scene scene, LoadSceneMode mode){
        // find spawnpoint an place the user therr
        GameObject spawnpoint = GameObject.FindGameObjectWithTag("StartLocation");
        ahp.SetPosition(spawnpoint.transform.position);
        ahp.SetRotation(spawnpoint.transform.rotation);
        print(spawnpoint.transform.position);
        
        ahp.useGrounding=true;
        ahp.gameObject.GetComponent<Rigidbody>().useGravity = true;
        Fader.FadeIn();
        
    }

    [Header("Player Info")]
    public bool isHost = false;
    public int playerIndex = -1;
    public int id;
    public string created_at;
    public string first_name;
    public string second_name;
    public string email_address;
    public string id_number;
    public int user_type_id = 99;    
    public string user_type;
    public int company_id;
    public string company_name;

    [Header("Body Parts")]
    public GameObject head;
    public GameObject l_Hand;
    public GameObject r_Hand;    

    [Header("Hand References")]
    [SerializeField] private GameObject defaultLHand;
    [SerializeField] private GameObject defaultRHand;
    [SerializeField] private GameObject multimeterLHand;
    [SerializeField] private GameObject multimeterRHand;
    public Finger l_Thumb;
    public Finger l_Index;
    public Finger l_Middle;
    public Finger l_Ring;
    public Finger l_Pinky;
    public Finger r_Thumb;
    public Finger r_Index;
    public Finger r_Middle;
    public Finger r_Ring;
    public Finger r_Pinky;

    public GameObject DefaultLHand => defaultLHand;
    public GameObject DefaultRHand => defaultRHand;

    [Header("OVR Parts")]
    public Transform tranQuest_Player;
    public Transform tranTracking_offset;
    public Transform tranOVRCameraRig;
    public Transform tranTrackingSpace;
    public Transform tranCenterEyeTracking;
    public bool IsAdmin()
    {
        return user_type_id < 3;
    }

    public AutoHandPlayer ahp;
    public OVRScreenFade Fader;
    IEnumerator refresh_I;
    bool shouldRefresh = false;

    public void StartRefresher()
    {
    }



    private void Start()
    {
        // if (DevelopmentState.instance && !DevelopmentState.instance.IsTesting)
        //     ToggleMovement(false);

        Realtime realTime = FindObjectOfType<Realtime>();
        if (realTime)
        {
            realTime.didConnectToRoom += SessionConnected;
            realTime.didDisconnectFromRoom += SessionDisconnected;
        }
        else
            Debug.LogError("Realtime Component not found");
    }

    private void SessionDisconnected(Realtime realtime)
    {
        StartRefresher();
    }

    private void SessionConnected(Realtime realtime)
    {
        shouldRefresh = false;
        if (refresh_I != null)
            StopCoroutine(refresh_I);
    }

    private void SessionNotRefreshed(string info)
    {
        Debug.Log("Session NOT Refreshed: " + info);
    }

}
