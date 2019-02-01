using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour {

	public bool LE_Moving;
	//Make sure the levers are not usable if the leaves are moving
	public static bool LE_InMotion;
	private bool LE_MovedLeft;
	private Vector2 LE_CurrentPosition;

	// Use this for initialization
	void Start () {
		LE_MovedLeft = false;
		LE_Moving = false;
		LE_InMotion = false;
		LE_CurrentPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if(LE_Moving)
		{
			if(!LE_MovedLeft)
			{
				LE_InMotion = true;
				//Move left
				if (Mathf.Abs(gameObject.transform.position.x - LE_CurrentPosition.x ) <20.0f)
				{
					gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.3f, gameObject.transform.position.y);
				}
				else
				{
					LE_MovedLeft = true;
					LE_Moving = false;
					LE_CurrentPosition = gameObject.transform.position;
					LE_InMotion = false;
				}
			}
			else
			{
				LE_InMotion = true;
				if (Mathf.Abs(gameObject.transform.position.x - LE_CurrentPosition.x) < 20.0f)
				{
					gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y);
				}
				else
				{
					LE_MovedLeft = false;
					LE_Moving = false;
					LE_CurrentPosition = gameObject.transform.position;
					LE_InMotion = false;
				}
			}
		}
		
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			col.gameObject.GetComponent<PlayerMovement>().P_Respawn();
		}
	}
}
