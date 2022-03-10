using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public AudioSource BlockPlaced;
    public Camera Cam;
    public float WaitTime;
    public GameObject Block;
    public float TotalBlocks;
    public Text BlocksLeftUI;

    private float _waitTill = -999f;
    private StarterAssets.StarterAssetsInputs _input;
    private void Start() {
        _input = GetComponent<StarterAssets.StarterAssetsInputs>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (TotalBlocks > 0) {
            PlaceBlock();
        }
    }
    public void PlaceBlock() {
        if (!_input.click) return;
        if (Time.time <= _waitTill) return;

        _waitTill = Time.time + WaitTime;

        TotalBlocks -= 1;
        BlocksLeftUI.text = "Blocks Left: " + TotalBlocks.ToString();

        //play sound
        BlockPlaced.time = 0.3f;
        BlockPlaced.Play();

        RaycastHit hit;
        if (!Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, Mathf.Infinity)) return;
        Debug.Log(hit.transform.name);

        //instantiate block with offset so it doesnt fly out of the floor 
        Instantiate(Block, new Vector3(hit.point.x, hit.point.y + 0.75f, hit.point.z), Quaternion.identity);

        //set the input.click to false
        _input.click = false;
    }
}
