using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    #region variables
    protected System.Random rnd = new System.Random();
    [SerializeField] protected int Wood = 0;
    [SerializeField] protected int Stone = 0;
    bool Uistate = false;
    IEnumerator respawnTimer;
    GameObject[] allTrees;
    Text WoodText;
    Text StoneText;
    Resource resource;
    UI_Generator ui;
    #endregion
    public void Gather(int amount, string type, GameObject obj)
    {
        switch(type)
        {
            case "Tree":
                Wood += amount;
                break;
            case "Stone":
                Stone += amount;
                break;
        }
        obj.GetComponent<Resource>().hp -= 2;
    }

    public void UseRecipe(Recipe recipe)
    {
        
    }
    public void Despawn(GameObject obj)
    {
        obj.SetActive(false);
        respawnTimer = Respawn(2.0f, obj);
        StartCoroutine(respawnTimer);
        
    }
    public IEnumerator Respawn(float waitTime, GameObject obj)
    {
        yield return new WaitForSeconds(waitTime);
        obj.SetActive(true);
        
        obj.GetComponent<Resource>().hp = rnd.Next(90, 120);
    }
    // Start is called before the first frame update
    
 
    void Start()
    {
        allTrees = GameObject.FindGameObjectsWithTag("Tree");

        foreach (GameObject obj in allTrees)
        {
            obj.AddComponent<Resource>();
        }
        resource = GameObject.Find("Tree").GetComponent<Resource>();
        WoodText = GameObject.Find("Wood_Counter").GetComponent<Text>();
        //StoneText = GameObject.Find("Stone_Counter").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(WoodText.text != Wood.ToString())
        {
            WoodText.text = Wood.ToString();
        }

        if(Uistate == false)
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                Uistate = true;
                ui.ShowUI();
            }
        }


        //if(StoneText.text != Stone.ToString())
        //{
        //    StoneText.text = Stone.ToString();
        //}
    }
}
