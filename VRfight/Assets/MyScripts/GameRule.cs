using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{

    public GameObject player;

    private GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        if (player != null) {
            Debug.Log("player has set for GameRule");
        }
        camera = GameObject.FindGameObjectWithTag("MainCamera");
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

        // move to direction of thumb stick angled
        var forwarding = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        MoveForward(forwarding);

        // This code is for debug
        if (Input.GetKeyDown(KeyCode.D)) {
            MoveForward(new Vector2(1f,0f));
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            MoveForward(new Vector2(-1f,0f));
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            MoveForward(new Vector2(0f,1f));
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            MoveForward(new Vector2(0f,-1f));
        }
    }

    Vector2 MoveForward(Vector2 controller) {
        var currentRotate = camera.transform.rotation;
        // move by force to the body.
        var body = player.GetComponent<Rigidbody>();
        // player's body is in x-z plane and controller axis is x-y, trade z-y.
        body.AddForce(new Vector3(controller.x * 100, 0, controller.y * 100), ForceMode.Force);
        return controller;
    }


}
