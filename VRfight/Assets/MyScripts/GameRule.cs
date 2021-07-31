using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (player != null) {
            Debug.Log("player has set for GameRule");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.A)) {
            Debug.Log("A pressed");
        }

    }    
}
