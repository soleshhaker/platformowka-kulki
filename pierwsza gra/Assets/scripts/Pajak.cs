﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pajak : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;
    public GameObject Player;
    AudioSource source;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.isActiveAndEnabled)
        {
            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);

            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        Player = GameObject.FindWithTag("Player");
        source = GameObject.Find("deathsound").GetComponent<AudioSource>();
        if (col.gameObject.tag == "Player")
        {

            Destroy(col.gameObject);
            source.Play();
            playeritems.Score--;
        }
    }
}