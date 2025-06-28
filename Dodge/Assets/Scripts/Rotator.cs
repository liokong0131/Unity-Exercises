using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationsSpeed = 60f;
    void Start() {
        
    }

    void Update() {
        transform.Rotate(0f, rotationsSpeed * Time.deltaTime, 0f);
    }
}

