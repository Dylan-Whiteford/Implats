using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject m_slotPrefab;
    public void Start(){
        InventorySystem.instance.onInventoryChagngedEvent.AddListener(OnUpdateInventory);

    }

    private void OnUpdateInventory(){
        print("working baby");
        foreach(Transform t in transform){
            Destroy(t.gameObject);
        }
        DrawInventory();
    }

    public void DrawInventory(){
        foreach (InventoryItem item in InventorySystem.instance.inventory){
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item){
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform,false);

        Slot slot = obj.GetComponent<Slot>();
        slot.Set(item);
    }
}
