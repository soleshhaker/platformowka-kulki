﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{

    void scenechange()
    {
        SceneManager.LoadScene("2nd lvl");
    }
    AudioSource source;
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player")
        {
            punkty.scoreValue = 0;
            source = GetComponent<AudioSource>();
            source.Play();

            

            Invoke("scenechange", 0.5f);

            gate1.gatestatus = "Poziom 2";

        }
    }

}
