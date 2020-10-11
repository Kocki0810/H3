using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;


public class Resource : Game_Controller
{
    Game_Controller Controller;
    public int hp;
    GameObject thisResource;
    bool respawning = false;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GameObject.Find("object_Game_Controller").GetComponent<Game_Controller>();
        hp = rnd.Next(90, 120);
        thisResource = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0 && respawning == false)
        {
            Controller.Despawn(thisResource);
            respawning = true;
        }
    }
}
