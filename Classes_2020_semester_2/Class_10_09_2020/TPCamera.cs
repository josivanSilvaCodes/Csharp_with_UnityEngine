
using UnityEngine;
using System.Collections;

public class TPCamera : MonoBehaviour
{
	float camPosX = 0f;
	float camPosY = 2f;
	float camPosZ = 1f;
	float camRotationX = 5;
	float camRotationY = 5;
	float camRotationZ = 5;
	float turnSpeed = 1;
	
	Vector3 offset = new Vector3(0,0,0);
	Vector3 abovePlayer = new Vector3(25,25,25);
    
	public Transform player;
	private void Start()
	{
		offset = new Vector3(player.position.x + camPosX, player.position.y + camPosY, player.position.z + camPosZ);
		transform.rotation = Quaternion.Euler(camRotationX, camRotationY, camRotationZ);
	}
    
	private void LateUpdate()
	{
		abovePlayer = new Vector3(player.position.x, player.position.y + 1, player.position.z);
		
		offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * 
		         Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) 
		         * offset;
		
		transform.position = player.position + offset;
		transform.LookAt(abovePlayer);
	}
}