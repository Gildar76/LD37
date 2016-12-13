using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour {

    public bool playerEntered;
    public GameObject gamemanager;

	// Use this for initialization
	void Start () {
        playerEntered = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerEntered = true;
        }
    }
}
