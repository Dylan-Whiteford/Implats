using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/**
 * <summary>
 *  - A wrapper class for items
 *  - Used to keep track of item count
 *  - Keeps a reference of the item data
 * </summary>
 */

[Serializable]
public class InventoryItem
{

    // Data of the item

    public InventoryItemData data {get; private set;}
    // Number of items in the inventory

    public int stackSize {get; private set;}

    /**
    * <summary>
    *   - constructor
    * </summary>
    * <param name="source">
    *   - the sciptable object associated with this wrapper class
    * </param>
    */
    public InventoryItem(InventoryItemData source)
    {
        data = source;
        AddToStack();
    }

    /**
     * <summary>
     * - increment the stack counter
     * </summary>
     */
    public void AddToStack()
    {
        stackSize++;
    }
    /**
     * <summary>
     * - decrement the stack counter
     * </summary>
     */
    public void removeFromStack(){
        stackSize--;
    }
}
