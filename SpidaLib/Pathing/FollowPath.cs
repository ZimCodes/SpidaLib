using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Needs to be used with the 'Path' Script
public class FollowPath : MonoBehaviour {
    public GameObject emptyObj;
    Path path;
    public float speed = 10f,mass = 5.0f;
    public bool isLooping = true;

    //Actual speed of vehicle
    private float curSpeed;

    private int curPathIndex;
    private Vector3 targetPoint;

    Vector3 velocity;
	// Use this for initialization
	void Start () {
        curPathIndex = 0;

        path = emptyObj.GetComponent<Path>();
        //get current velocity of the vehicle
        velocity = this.transform.forward;
        
	}
	
	// Update is called once per frame
	void Update () {
        //Establish the speed property
        curSpeed = speed * Time.deltaTime;

        targetPoint = path.GetPoint(curPathIndex);

        //If [this object] reach the radius within the path then move to 
        //next point in the path
        if (Vector3.Distance(this.transform.position,targetPoint) < path.radius)
        {
            //Don't move the object if path is finished
            if (curPathIndex < path.Length - 1) curPathIndex++;
            else if (isLooping) curPathIndex = 0;
            else return;
        }
        //Calculate the next Velocity towards the path
        if (curPathIndex >= path.Length-1 && !isLooping)
        {
            velocity += Steer(targetPoint,true);
            
        }
        else
        {
            velocity += Steer(targetPoint);
            
        }
        //Move the whicle according to the velocity
        this.transform.position += velocity;
        //Rotate the vehicle towards the desired Velocity
        this.transform.rotation = Quaternion.LookRotation(velocity);
	}
    public Vector3 Steer(Vector3 _target,bool _isfinalpoint = false)
    {
        //Calculate the directional vector from the current 
        //position towards the target point
        Vector3 desiredVelocity = _target - this.transform.position;
        float dist = desiredVelocity.magnitude;

        //Normalize the desired Velocity
        desiredVelocity.Normalize();

        //Calculate the velocity according to the speed
        if (_isfinalpoint && dist < 10.0f)
        {
            //Speed Accumulation will ---DECREASE--- as [this object] gets closer to the [target point]
            desiredVelocity *= (curSpeed * (dist / 10.0f));
        }
        else
        {
            //Speed Accumulation will ---REMAIN FIXED--- as [this object] gets closer to the [target point]
            desiredVelocity *= curSpeed;
        }
        //Calculate the force Vector
        Vector3 steeringForce = desiredVelocity - velocity;//Removes this.transform.forward from desiredVelocity
        Vector3 acceleration = steeringForce / mass;//Formula: { Force = mass * acceleration } 

        return acceleration;
    }
}
