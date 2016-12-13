using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTilt : MonoBehaviour {

    public float speed = 1000000f;
    public float restoreSpeed;
    //public float rotationLimit = 0.2f;
    // Use this for initialization
    //public float smooth = 2.0F;
    public float tiltAngle = 30.0F;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput(Time.deltaTime);

        restoreRotation(Time.deltaTime);
        
        //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z));
    }

    public void restoreRotation(float delta)
    {
        Vector3 resetRotation = new Vector3(0, 0, 0);
        if (Input.GetAxisRaw("Vertical") == 0)
        {
            if (transform.rotation.x < -0.0005f) resetRotation.x = delta * restoreSpeed;
            if (transform.rotation.x > 0.0005f) resetRotation.x = delta * restoreSpeed * -1;
        }

        Debug.Log( "restoring x = " +  transform.rotation.x);


        //if (transform.rotation.y < -0.0005f) resetRotation.y = delta * restoreSpeed;
        //if (transform.rotation.y > 0.0005f) resetRotation.y = delta * restoreSpeed * -1;
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if (transform.rotation.z < -0.0005f) resetRotation.z = delta * restoreSpeed;
            if (transform.rotation.z > 0.0005f) resetRotation.z = delta * restoreSpeed * -1;
        }

        transform.Rotate(resetRotation);
    }

    public bool HandleInput(float delta)
    {
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle * -1; ;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle ;
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, delta * speed);
        //Debug.Log(Input.GetAxis("Horizontal") * speed * delta);
        //Vector3 rotation = new Vector3((transform.rotation.x < rotationLimit && transform.rotation.x > -rotationLimit) ? Input.GetAxis("Vertical") * speed * delta : 0 , 0, (transform.rotation.z < rotationLimit && transform.rotation.z > -rotationLimit) ? Input.GetAxis("Horizontal") * speed * delta * -1 : 0);
        //Debug.Log("x = " + rotation.x);
        //Debug.Log("y = " + rotation.y);
        //Debug.Log("z = " + rotation.z);
        //transform.Rotate(1, 1, 0);
        //transform.Rotate(rotation);
        //rotation.x += transform.rotation.x;
        //rotation.z += transform.rotation.z;
        //transform.rotation = Quaternion.Euler(rotation);
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Debug.Log("Input is set");
            return true;
        } else
        {
            return false;
        }
    }
}
