using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Keybindings
{
    Game_Controller Controller;
    GameObject targetResource;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GameObject.Find("object_Game_Controller").GetComponent<Game_Controller>();

    }

    // Update is called once per frame
    void Update()
    {
        

        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, 2))
        {
            if(Input.GetKeyDown(GatherResource))
            {
                targetResource = hit.collider.gameObject;
                if(hit.collider.gameObject.CompareTag("Stone"))
                {
                    Controller.Gather(1, "Stone", targetResource);
                }
                else if(hit.collider.gameObject.CompareTag("Tree"))
                {
                    Controller.Gather(1, "Tree", targetResource);
                }
            }
        }
        //if (Physics.Raycast(transform.position, fwd, out hit, 2) && hit.collider.gameObject.CompareTag("Stone"))
        //{
        //}
    }
}
