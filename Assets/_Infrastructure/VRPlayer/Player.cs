using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;
using Normal.Realtime;
using System;
public class Player : MonoBehaviour
{
    public static Player instance;
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Debug.LogError("There is more than one instance of Player in this scene");
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

    IEnumerator refresh_I;
    bool shouldRefresh = false;

    public void StartRefresher()
    {
        //Debug.Log("Refreshing: " + "1");
        // refresh_I = Refresh_I();
        // StartCoroutine(refresh_I);
    }

    // IEnumerator Refresh_I()
    // {
    //     shouldRefresh = true;
    //     WWWForm www = new WWWForm();
    //     www.AddField("user_id", id);
    //     WaitForSeconds wait = new WaitForSeconds(5);
    //     while (shouldRefresh)
    //     {            
    //         yield return wait;
    //         yield return Api.instance.RefreshSession_I(www, SessionRefreshed, SessionNotRefreshed);
    //     }
    // }

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

    // private void SessionRefreshed(string info)
    // {
    //     if (shouldRefresh)
    //     {
    //         Invites.instance.ParseInvites(info);
    //     }
    // }

    private void SessionNotRefreshed(string info)
    {
        Debug.Log("Session NOT Refreshed: " + info);
    }

    public void ToggleMovement(bool flag)
    {
        AutoHandPlayer ahp = GetComponentInChildren<AutoHandPlayer>();
        if (ahp)
        {
            ahp.useMovement = flag;
        }
    }

}
