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
        if(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)) {
            Debug.Log("Primary Trigger pressed");
        }

        if(OVRInput.Get(OVRInput.Button.One)) {
            Debug.Log("One pressed");
        }

        if(OVRInput.Get(OVRInput.Button.Two)) {
            Debug.Log("Two pressed");
        }

        // 前の方向に移動する
        var forwarding = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

    }    
}
