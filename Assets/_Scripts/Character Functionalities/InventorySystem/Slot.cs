using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using System;
/**
 * <summary>
 * - this script is for an item slot for the inventory bar gameobject
 * </summary>
 */
 [Serializable]
public class Slot : MonoBehaviour
{
    private InventoryItem item;

    [SerializeField]
    private Image m_icon;

    [SerializeField]
    private TextMeshProUGUI m_label;

    [SerializeField]
    private GameObject m_stackObj;
    
    [SerializeField]
    private TextMeshProUGUI m_stackLabel;

    [SerializeField]
    private Button m_button;
    
    public void Set(InventoryItem item){
       this.item = item;
       // print(item.data.displayName);
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;
        m_stackLabel.text = item.stackSize.ToString();
    
        if(item.stackSize <= 1){
            m_stackObj.SetActive(false);
            return;
        }
        m_stackLabel.text = item.stackSize.ToString();
    }

    public void Awake(){
        m_button.onClick.AddListener(dropItem);
    }

    public void dropItem(){
        GameObject obj = Instantiate(item.data.prefab);
        obj.transform.SetPositionAndRotation(FreeCamController.instance.gameObject.transform.position,new Quaternion(0,0,0,0));
        InventorySystem.instance.Remove(item.data);
    }


}
