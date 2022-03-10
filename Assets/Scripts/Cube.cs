using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Transform StartPos;
    void OnTriggerEnter(Collider player) {
        
        if (player.gameObject.tag == "Player") {
            var controller = player.GetComponent<StarterAssets.FirstPersonController>();
            controller.OnLava = true;
        }
       
    }
}
