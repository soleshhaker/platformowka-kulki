﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class endgame1 : MonoBehaviour


{
    public void gaterestart()
    {
        gate1.gatestatus = null;
    }



    void OnTriggerEnter(Collider col)
    {
        BoxCollider gatecolider;

        if (col.gameObject.name == "Sphere" && punkty.scoreValue > 100)
        {
            gate1.gatestatus = "Zebrano ponad 100 punktów";
            Invoke("gaterestart", 3);
            gatecolider = GameObject.Find("gatecolider").GetComponent<BoxCollider>();
            gatecolider.enabled = false;
            Application.Quit();
        }

        if (col.gameObject.name == "Sphere" && punkty.scoreValue < 100)
        {
            gate1.gatestatus = "Nie zebrano 100 punktów";
            Invoke("gaterestart", 3);

        }
    }
}