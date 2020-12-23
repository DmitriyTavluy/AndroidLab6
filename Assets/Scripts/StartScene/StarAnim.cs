﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnim : MonoBehaviour
{
    private SpriteRenderer star;
    private float _movementSpeed = 0.2f;

    void Start ()
    {
        star = GetComponent <SpriteRenderer> ();
        Destroy (gameObject, 5f);
    }
     void Update ()
    {
        star.color = new Color (star.color.r, star.color.g, star.color.b, Mathf.PingPong (Time.time / 2.5f, 1.0f));

        transform.position += transform.up * Time.deltaTime * _movementSpeed;
    }
}
