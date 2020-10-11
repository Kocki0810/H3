using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UI_Generator : Game_Controller
{
    GameObject go_Wood;
    GameObject go_Stone;
    GameObject btn_test;
    Text TextWood;
    Text TextStone;
    Button btnTest;
    Font Arial;
    RectTransform rect;
    Image image;
    void Awake()
    {
        
        btn_test = new GameObject("Test_Button");
        go_Wood = new GameObject("Wood_Counter");
        go_Stone = new GameObject("Stone_Counter");

        btnTest = btn_test.AddComponent<Button>();
        TextWood = go_Wood.AddComponent<Text>();
        TextStone = go_Stone.AddComponent<Text>();
        Arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        TextWood.transform.SetParent(transform);
        TextStone.transform.SetParent(transform);
        btnTest.transform.SetParent(transform);


        image = btn_test.AddComponent<Image>();
        image.color = Color.white;
        image = (Image)Resources.GetBuiltinResource(typeof(Image), "unity_builtin_extra.png");
        //rect = btn_test.AddComponent<RectTransform>();
        rect = btn_test.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector3(-500, 200, 0);

        rect = go_Wood.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector3(-500, 250, 0);

        rect = go_Stone.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector3(-500, 230, 0);

        TextWood.text = Wood.ToString();
        TextWood.font = Arial;
        TextWood.material = Arial.material;

        TextStone.text = Stone.ToString();
        TextStone.font = Arial;
        TextStone.material = Arial.material;
      
    }
 
    public void ShowUI()
    {
        Debug.Log("Test button");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
