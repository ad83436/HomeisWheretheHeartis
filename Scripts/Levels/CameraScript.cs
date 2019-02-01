using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float C_UpperBound;
    public float C_LowerBound;
    public float C_LeftBound;
    public float C_RightBound;

	public float C_Speed;
	private float C_Vertical;
	private Vector3 C_StartingPosition;
	private GameObject C_Player;

	public float C_MaxDistance;	
	public static bool C_FollowPlayer;

	// Update is called once per frame

	private void Start()
	{
		C_FollowPlayer = true;
		C_Player = GameObject.Find("Player");
        C_StartingPosition = C_Player.transform.position;
        C_StartingPosition.z = -10.0f;
        transform.position = C_StartingPosition;
    }
	void LateUpdate()
    {
		if(!ControlManager.CM_PlayerControl)
		{

			C_Vertical = Input.GetAxis("Vertical");

			if (C_Vertical>0.0f)
			{
				if ( gameObject.transform.position.y - C_StartingPosition.y < C_MaxDistance)
				{
					gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + C_Vertical * C_Speed,gameObject.transform.position.z);
				}
			}
			else if (C_Vertical < 0.0f)
			{
				if (C_StartingPosition.y- gameObject.transform.position.y  < C_MaxDistance)
				{
					gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + C_Vertical * C_Speed, gameObject.transform.position.z);
				}
			}
		}

		if(C_FollowPlayer)
		{
            Vector3 realPos = C_Player.transform.position;
            realPos.z = -10.0f;

            //only runs if the bounds are set. else just ignore bounds
            if (C_LeftBound != 0.0f | C_RightBound != 0.0f | C_UpperBound != 0.0f | C_LowerBound != 0.0f)
            {
                if (realPos.x > C_RightBound)
                {
                    realPos.x = C_RightBound;
                }

                if (realPos.x < C_LeftBound)
                {
                    realPos.x = C_LeftBound;
                }

                if (realPos.y > C_UpperBound)
                {
                    realPos.y = C_UpperBound;
                }

                if (realPos.y < C_LowerBound)
                {
                    realPos.y = C_LowerBound;
                }
            }

            //sets the new position
            transform.position = realPos;
        }

	}
}
