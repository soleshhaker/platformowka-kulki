﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class itemdescription2 : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
    , IPointerClickHandler
{
    GameObject objToSpawn;
    GameObject ui;
    int istext;
    float speed;
    public TextAlignmentOptions alignment { get; set; }

    void Awake()
    {
        ui = GameObject.Find("status");
        int istext = 0;
        speed = speedpotion.speedvalue;
        Debug.Log(speed);
    }

    void usepotion(float speed)
    {
        CharacterControls.speed += speed;
    }

    void endpotion(float speed)
    {
        CharacterControls.speed -= speed;
    }
    void Update()
    {
        
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
            objToSpawn.GetComponent<Text>().text = "Potion than enhances speed, lasts for 30 seconds (Click to use)";
            objToSpawn.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            istext = 1;


            Debug.Log(inventory.speedpotionobtained);
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
        usepotion(speed);
        Debug.Log(speed);

        Invoke("endpotion(speed)", 30);
        inventory.speedpotionobtained -= 1;
        istext = 1;
        if (inventory.speedpotionobtained == 0)
        {


            speedpotion.spdpotion.GetComponent<Image>().enabled = false;
            speedpotion.speedpotionslot.GetComponent<Image>().enabled = false;
            
        }

        
    }
}