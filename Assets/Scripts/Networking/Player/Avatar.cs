using UnityEngine;
using System.Collections;


/// <summary>
/// SCRIPT FOR ALL NETWORKED CHARACTERS THAT ARE NOT THE PLAYER
/// </summary>
public class Avatar : MonoBehaviour {

    private Vector3 targetPosition;

    public Vector3 TargetPosition
    {
        get { return targetPosition; }
        set { targetPosition = value; }
    }
	public Color color;
	public float lag; //ping
    private float moveSpeed = 60.00f;

    public int team = -1;
	
	
	
	// Use this for initialization
	void Start () 
	{
	}

    public void launchLag(double deltaTime)
    {
        Vector3 distanceVector = targetPosition - transform.position;
        transform.position += (distanceVector.normalized * moveSpeed);
    }
	
	void init(Vector3 spawnPos, Color playerColor, int teamNum)
	{
		transform.position = spawnPos;
        targetPosition = spawnPos;
		color = playerColor;
        team = teamNum;
	}
	
	// LERP THE CHARACTER TO THE TARGET POSITION
	void Update () 
	{
		//Debug.Log("Avatar Update Loop...");
		if (Vector3.Distance(transform.position, targetPosition) <= 5)
		{
			//Debug.Log("\tHas Arrived at " +targetPosition);
			transform.position = targetPosition;	
		}
		else
		{
			//Debug.Log("\tMoving. Current Position = " + transform.position);
			Vector3 distanceVector = targetPosition - transform.position;
			transform.position += (distanceVector.normalized * moveSpeed * Time.deltaTime);
		}
	}
}
