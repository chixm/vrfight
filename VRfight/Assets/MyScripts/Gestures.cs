using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestures : MonoBehaviour
{
    public GameObject player;
    public GameObject headAnchor;
    public GameObject leftHandAnchor;
    public GameObject rightHandAnchor;

    // Start is called before the first frame update 
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) &&
             OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) &&
             OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && 
             OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger)
             )
        {
            // Fly for Both Hands direction
            var head = headAnchor.transform.localPosition;
            var left = leftHandAnchor.transform.localPosition;
            var right = rightHandAnchor.transform.localPosition;
            var avgVector = (left + right) / 2;
            var direction = avgVector - head;
            // move by force to the body.
            var body = player.GetComponent<Rigidbody>();
            // add force to move
            body.AddForce(direction * 100, ForceMode.Acceleration);
        }
    }
}
