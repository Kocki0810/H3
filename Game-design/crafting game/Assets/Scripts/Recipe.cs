using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    //name of item... duh
    public string itemName { get; set; }
    //what type it is item, equipment, food?, rescource etc
    public string itemType { get; set; }
    //what it costs to make the item, and how much it costs in following order: Wood - 10; remember the ; at the end
    public List<string> resourceInfo { get; set; }
    //What it does add an item to inventory, upgrade stats etc syntax is: Add Item - itemID - quantity; StatIncrease - StatID - amount to increase
    public string function { get; set; }
     
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
