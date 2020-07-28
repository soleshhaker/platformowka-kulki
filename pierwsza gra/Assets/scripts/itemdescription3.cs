﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class itemdescription3 : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
    , IPointerClickHandler
{
    GameObject objToSpawn;
    GameObject ui;
    int istext;
    int jump;
    public TextAlignmentOptions alignment { get; set; }

    void Awake()
    {
        ui = GameObject.Find("status");
        int istext = 0;
      
        
    }

    void usepotion(int jump)
    {
        playeritems.Jump += jump;
    }

    void endpotion(int jump)
    {
        playeritems.Jump -= jump;
    }
    void Update()
    {
        jump = jumppotion.jumpvalue;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ui = GameObject.Find("status");

        if (istext == 0)
        {
            objToSpawn = new GameObject("itemdesc");
            objToSpawn.AddComponent<Text>();
            objToSpawn.transform.SetParent(ui.transform);
            objToSpawn.transform.position = new Vector3(300, 0, 3);
            objToSpawn.GetComponent<RectTransform>().localPosition = new Vector3(10, -170, 1);
            objToSpawn.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 60);
            objToSpawn.GetComponent<Text>().text = "Potion than enhances jump, lasts for 30 seconds (Click to use)";
            objToSpawn.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            istext = 1;


            Debug.Log(playeritems.Jumppotion);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        objToSpawn.GetComponent<Text>().text = null;
        istext = 0;
        Destroy(objToSpawn);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ui = GameObject.Find("status");
        Debug.Log("Pointer Click");

        objToSpawn.GetComponent<Text>().text = "Potion used!";
        usepotion(jump);
        Debug.Log(jump);

        Invoke("endpotion(jump)", 30);
        playeritems.Jumppotion -= 1;
        istext = 1;
        if (playeritems.Jumppotion == 0)
        {


            GameObject.Find("Image3").GetComponent<Image>().enabled = false;
            GameObject.Find("InventorySlot3").GetComponent<Image>().enabled = false;

        }


    }
}