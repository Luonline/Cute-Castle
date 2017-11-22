﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFrogBehaviour : MonoBehaviour {
    public Rigidbody2D rb;
    private GameObject player;
    private MonsterSight monstersight;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        monstersight = gameObject.GetComponent<MonsterSight>();
    }

    // Update is called once per frame
    void Update() {
        if (monstersight.iSeeYou) {
            if (rb.velocity.y == 0) {
                if (player.transform.position.x < this.transform.position.x) {
                    rb.AddForce(new Vector3(-2, 3, 0), ForceMode2D.Impulse);
                }
                else if (player.transform.position.x > this.transform.position.x) {
                    rb.AddForce(new Vector3(2, 3, 0), ForceMode2D.Impulse);
                }
                else {
                    rb.AddForce(new Vector3(2, 3, 0), ForceMode2D.Impulse);
                }

            }
        }
    }
}