using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;
using Normal.Realtime;
using System;
// using _Infrastructure.Interactables.Equipment;
// using _Infrastructure.Interactables.Multimeter;
// using _Infrastructure.Inventory;
// using Shared.DependencyInjection;

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

    // [Header("Player Equipment Placeholders")]
    // [SerializeField] private GlovesPlaceholder glovesPlaceholder;
    // [SerializeField] private HelmetPlaceholder helmetPlaceholder;
    // [SerializeField] private GogglesPlaceholder gogglesPlaceholder;
    // [SerializeField] private InsulatedGlovesPlaceholder insulatedGlovesPlaceholder;
    // [SerializeField] private RobePlaceholder robePlaceholder;
    
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

    // [Header("Multimeter References")]
    // [SerializeField] private MultimeterWire multimeterRedWire;
    // [SerializeField] private MultimeterWire multimeterBlackWire;

    // public GlovesPlaceholder GlovesPlaceholder => glovesPlaceholder;
    // public HelmetPlaceholder HelmetPlaceholder => helmetPlaceholder;
    // public GogglesPlaceholder GogglesPlaceholder => gogglesPlaceholder;
    // public InsulatedGlovesPlaceholder InsulatedGlovesPlaceholder => insulatedGlovesPlaceholder;
    // public RobePlaceholder RobePlaceholder => robePlaceholder;
    public GameObject DefaultLHand => defaultLHand;
    public GameObject DefaultRHand => defaultRHand;
    public GameObject MultimeterLHand => multimeterLHand;
    public GameObject MultimeterRHand => multimeterRHand;
    // public MultimeterWire MultimeterRedWire => multimeterRedWire;
    // public MultimeterWire MultimeterBlackWire => multimeterBlackWire;

    [Header("OVR Parts")]
    public Transform tranQuest_Player;
    public Transform tranTracking_offset;
    public Transform tranOVRCameraRig;
    public Transform tranTrackingSpace;
    public Transform tranCenterEyeTracking;
    public AutoHandPlayer autoHandPlayer;
    public OVRScreenFade fader;

    char[] charPPE = new char[] { '0', '0', '0' };

    //private TutorialService tutorialService;

    // public void ActivateEquipment(InventoryItemIds equipmentId)
    // {
    //     if (tutorialService == null)
    //         tutorialService = InstanceLocator.Get<TutorialService>();
        
    //     switch (equipmentId)
    //     {
    //         case InventoryItemIds.Gloves:
    //             GlovesPlaceholder.gameObject.SetActive(true);
    //             break;
    //         case InventoryItemIds.Goggles:
    //             GogglesPlaceholder.gameObject.SetActive(true);
    //             break;
    //         case InventoryItemIds.Robe:
    //             RobePlaceholder.gameObject.SetActive(true);
    //             break;
    //         case InventoryItemIds.Helmet:
    //             HelmetPlaceholder.gameObject.SetActive(true);
    //             break;
    //         case InventoryItemIds.InsulatedGloves:
    //             InsulatedGlovesPlaceholder.gameObject.SetActive(true);
    //             break;
    //         case InventoryItemIds.Multimeter:
    //             break;
    //         default:
    //             throw new ArgumentOutOfRangeException(nameof(equipmentId), equipmentId, null);
    //     }
        
    // }
    
    // public void DeactivateEquipment(InventoryItemIds equipmentId)
    // {
    //     if (tutorialService == null) 
    //         tutorialService = InstanceLocator.Get<TutorialService>();
        
    //     switch (equipmentId)
    //     {
    //         case InventoryItemIds.Gloves:
    //             GlovesPlaceholder.gameObject.SetActive(false);
    //             break;
    //         case InventoryItemIds.Goggles:
    //             GogglesPlaceholder.gameObject.SetActive(false);
    //             break;
    //         case InventoryItemIds.Robe:
    //             RobePlaceholder.gameObject.SetActive(false);
    //             break;
    //         case InventoryItemIds.Helmet:
    //             HelmetPlaceholder.gameObject.SetActive(false);
    //             break;
    //         case InventoryItemIds.InsulatedGloves:
    //             InsulatedGlovesPlaceholder.gameObject.SetActive(false);
    //             break;
    //         case InventoryItemIds.Multimeter:
    //             break;
    //         default:
    //             throw new ArgumentOutOfRangeException(nameof(equipmentId), equipmentId, null);
    //     }
               
    // }

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

    // public void Teleport(Transform target)
    // {
    //     /*Player.instance.transform.position = target.position;
    //     Player.instance.transform.rotation = target.rotation;
    //     return;*/

    //     if (tranQuest_Player && tranTracking_offset && tranCenterEyeTracking)
    //     {
    //         Vector3 nPosition;
    //         RaycastHit hit;
    //         if (false && Physics.Raycast(target.position, target.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
    //         {
    //             nPosition = hit.point;
    //             Debug.Log("Teleport Target Hit: " + hit.collider.gameObject.name + " (" + target.gameObject.name + ")");
    //         }
    //         else
    //             nPosition = target.position;

    //         transform.position = nPosition;
    //         autoHandPlayer.SetPosition(nPosition);
    //         //Player.instance.transform.position = nPosition;            
    //         //Player.instance.transform.rotation = transform.rotation;
    //         tranTracking_offset.rotation = target.rotation;
    //         return;


    //         transform.position = nPosition;            
    //         tranTracking_offset.rotation = target.rotation;

    //         if (fader)
    //             fader.FadeIn();
    //     }
    //     else
    //         Debug.LogError("Do not have all required components for teleporting");
    //     //teleport_Offset.localPosition = Vector3.zero;
    //     //teleport_Offset.rotation = newPosition.rotation;
    // }


    public void EquipPPE(int i, bool flag)
    {
        charPPE[i] = flag ? '1' : '0';
        //if (NetworkedPlayer.instance)
            //NetworkedPlayer.instance.EquipPPE(new string(charPPE));
    }

    //[ContextMenu("Go To working Area As Worker")]
    // void Test_GoToWorkingSpace_AsWorker()
    // {
    //     Teleport(WorkingAreas.instance.areas[0].tranStartPoint);
    // }

    //[ContextMenu("Go To working Area As Admin")]
    // void Test_GoToWorkingSpace_AsAdmin()
    // {
    //     Teleport(WorkingAreas.instance.areas[0].tranFacilitatorPoint);
    // }


}
