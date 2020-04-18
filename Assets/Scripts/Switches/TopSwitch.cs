﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSwitch : MonoBehaviour
{
    private List<Collider2D> colliders;
    private bool isDestroyed;

    private void Awake() {
        colliders = new List<Collider2D>();
        isDestroyed = false;
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        
        if(!colliders.Contains(player) && player.name != "Boulder" && player.name != "Block"){
            colliders.Add(player);
        }
        
        if(colliders.Count > 1 && !isDestroyed){
            isDestroyed = true;
            //make doors open
            GameObject[] bottomDoor = GameObject.FindGameObjectsWithTag("Door Top");
            Destroy(bottomDoor[0]);
            Destroy(bottomDoor[1]);
        } 
    }

    void OnTriggerExit2D(Collider2D player){
        colliders.Remove(player);
        
    }
}