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

        // Move by Thumb Stick
        // move to direction of thumb stick angled
        var controllerDirection = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Move(controllerDirection);
        var secondaryDirection = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        Rotate(secondaryDirection);

        // This code is for debug
        if (Input.GetKeyDown(KeyCode.D)) {
            Move(new Vector2(10f,0f));
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            Move(new Vector2(-10f,0f));
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            Move(new Vector2(0f,10f));
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            Move(new Vector2(0f,-10f));
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            player.transform.RotateAround(Vector3.forward, Vector3.up, -10);
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            player.transform.RotateAround(Vector3.forward, Vector3.up, 10);
        }

        AreaRestriction();
    }

    void Move(Vector2 controllerDirection) {
        // camera direction
        var forwardDirection = player.GetComponentInChildren<Camera>().transform.rotation;
        // controller direction to HMD plane
        Vector3 directionToGo = new Vector3(controllerDirection.x, 0, controllerDirection.y);
        // rotate around HMD rotate
        Vector3 forceToMove =  forwardDirection * directionToGo * 10;
        // move by force to the body.
        var body = player.GetComponent<Rigidbody>();
        // speed limit of acceleration
        if (body.velocity.magnitude > 10.0f) {
            return;
        }
        // add force to move
        body.AddForce(forceToMove, ForceMode.Acceleration);
    }

    // Rotate the character by thumbstick
    void Rotate(Vector2 controllerDirection) {

        float angle = 0.0f; //Mathf.Atan2(controllerDirection.x, controllerDirection.y) * Mathf.Rad2Deg;
        if (controllerDirection.x > 0) {
            angle = 90.0f * Time.deltaTime;
        } else {
            angle = -90.0f * Time.deltaTime;
        }
        player.transform.RotateAround(player.transform.position, Vector3.up, angle);
    }

    // player does not go to under ground or too high in the sky.
    void AreaRestriction() {
        if (this.player.transform.position.y < 0) {
            this.player.transform.position = new Vector3(this.player.transform.position.x, 0, this.player.transform.position.z);
        }
        if (this.player.transform.position.y > 1000) {
            this.player.transform.position = new Vector3(this.player.transform.position.x, 1000, this.player.transform.position.z);
        }
    }
}
