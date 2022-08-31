using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Normal.Realtime;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance;

    public Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;

    public List<InventoryItem> inventory {get; private set;}

    private void Awake(){
        // Check for singleton
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }

        instance.inventory = new List<InventoryItem>();
        instance.m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }
    /**
    * <summary>
    *   - A getter function for the inventory items
    * </summary>
    * <param name="referenceData"> 
    *   - the lookup for the dictionary that stores the items 
    * </param>
    * <returns> 
    *   - an item from the inventory 
    * </returns>
    */
    public InventoryItem Get(InventoryItemData referenceData){
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)){
            return value;
        }
        return null;
    }

    /**
    * <summary>
    *   - An add function to add items from the inventory items
    * </summary>
    * <param name="referenceData"> 
    *   - the lookup for the dictionary that stores the items 
    * </param>
    */
    public void Add(InventoryItemData referenceData){
        print("Inventory system is adding");
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)){
            value.AddToStack();
        }
        else{
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            print(inventory[0].data.displayName);
            m_itemDictionary.Add(referenceData,newItem);
        }
        onInventoryChagngedEvent.Invoke();
    }
    /**
    * <summary>
    *   - A remove function to delete items from the inventory items
    * </summary>
    * <param name="referenceData"> 
    *   - the lookup for the dictionary that stores the items 
    * </param>
    */
    public void Remove(InventoryItemData referenceData){
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)){
            value.removeFromStack();

            if(value.stackSize == 0){
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
            onInventoryChagngedEvent.Invoke();
        }
    }

    /**
     * <summary>
     * 
     * </summary>
     */
    public UnityEvent onInventoryChagngedEvent;
}
