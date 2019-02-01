using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable {

	public enum L_Directions
	{
		Horizontal,
		Vertical
	};
	public L_Directions L_Direction;
	public GameObject L_Door;
	public static bool L_RespawnDoor;
	private bool L_Horizontal;
	private bool L_Vertical;
	private Vector2 L_DoorStartingPosition;
	private bool L_Triggered;

	private void Start()
	{
		L_Horizontal = false;
		L_Vertical = false;
		L_RespawnDoor = false;
		L_DoorStartingPosition = L_Door.transform.position;
		L_Triggered = false;
	}

	private void Update()
	{
		if(L_Horizontal)
		{

			L_Door.transform.position = new Vector2(L_Door.transform.position.x + 0.5f, L_Door.transform.position.y);

			if (Mathf.Abs(L_Door.transform.position.x - L_DoorStartingPosition.x)>=4.0f)
			{
				L_Horizontal = false;
			}
		}
		else if(L_Vertical)
		{
			L_Door.transform.position = new Vector2(L_Door.transform.position.x , L_Door.transform.position.y - 0.5f);

			if (Mathf.Abs(L_Door.transform.position.y - L_DoorStartingPosition.y) >= 4.0f)
			{
				L_Vertical = false;
			}
		}

		if(L_RespawnDoor)
		{
			L_Door.transform.position = L_DoorStartingPosition;
			L_RespawnDoor = false;
		}
	}

	public override void I_Activate()
	{
		if (!L_Triggered)
		{
			AudioManager.instance.PlaySound("FlipLever");
			//Flip switch

			switch (L_Direction)
			{
				case L_Directions.Horizontal:
					L_Horizontal = true;
					break;
				case L_Directions.Vertical:
					L_Vertical = true;
					break;
			}
			L_Triggered = true;
		}
	}
}
