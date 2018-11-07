﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropZone : MonoBehaviour
{
    [SerializeField] private float amountOfKeys;
    [SerializeField] private float speed;

    [SerializeField] private GameObject rocket;
    public GameObject player;

    private AudioSource audioData;
    [SerializeField] private AudioClip winSound;

    private bool allKeys = false;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Collider[] keys = Physics.OverlapSphere(transform.position, 0.5f);
        if(keys.Length == amountOfKeys)
        {
            allKeys = true;
            audioData.PlayOneShot(winSound);
        }

        if(allKeys)
        {
            //Destroy(player);
            LaunchRocket();
        }
    }


    private void LaunchRocket()
    {
        rocket.transform.Translate(Vector3.up * speed * Time.deltaTime);
        Invoke("EndGame", 3f);
    }

    private void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}
