using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationNodeManager : MonoBehaviour
{
    // singleton
    public static LocationNodeManager Instance;

    // the node that has is currently in the open state
    public LocationNode activeNode;


    // Start is called before the first frame update
    void Start()
    {
         //singleton check
        if (Instance != null && Instance != this) 
        { 
            print("WARN!: duplicate Location Node Deteced");
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateActive(LocationNode active){

        if (this.activeNode != active){
            // close previous node 
            if(activeNode){
                activeNode.close();
            }
            
            activeNode = active;
            // open new node
            activeNode.open();

        }

    }

    public void closeActive(){
        if(activeNode){
            activeNode.close();
            activeNode=null;
        }
    }
    

}
