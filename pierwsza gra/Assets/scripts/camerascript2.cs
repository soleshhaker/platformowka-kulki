﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Cinemachine;
using System.Security.Cryptography;

public class camerascript2 : MonoBehaviour
{

    public GameObject player;
    public GameObject vcam1;
    public GameObject vcam2;
    public GameObject vcam3;
    public GameObject vcam4;


    void Start()
    {
        player = GameObject.Find("player");
        vcam1 = GameObject.Find("vcam1");
        vcam2 = GameObject.Find("vcam2");
      
    }
    void Update()
    {
        if (changecharacter.ischaracterchanged == true)
        {
            vcam3 = GameObject.Find("character2(Clone)").transform.Find("vcam1_2").gameObject;
            vcam4 = GameObject.Find("character2(Clone)").transform.Find("vcam2_2").gameObject;
        }
        }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player" && changecharacter.ischaracterchanged == false)
        {

            vcam1.SetActive(true);
            vcam2.SetActive(false);
            
        }

        if (col.gameObject.tag == "Player" && changecharacter.ischaracterchanged == true)
        {

            vcam1.SetActive(false);
            vcam3.SetActive(true);
            vcam4.SetActive(false);
        }
    }

}