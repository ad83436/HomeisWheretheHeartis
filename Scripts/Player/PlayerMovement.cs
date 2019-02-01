using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D P_RigidBody;
	private float P_Horizontal;
	private float P_Vertical;
	private bool P_CanInteract;
	private Interactable P_Intreactable;
	private Vector2 P_StartingPosition;
	private VGUI P_VGUI;
    private bool P_IsSliding;
    private Vector2 P_SlideDir;
    private Vector3 P_lastPos;
    private float P_PosTimer;
	private Animator P_Animator;
    private AudioManager P_AudioM;

	public float P_Speed;


	// Use this for initialization
	void Start()
    {
		Cursor.visible = false;
        P_lastPos = transform.position;
        P_IsSliding = true;
        P_SlideDir = Vector2.zero;
        P_RigidBody = gameObject.GetComponent<Rigidbody2D>();
		P_Animator = gameObject.GetComponent<Animator>();
		P_CanInteract = false;
		P_StartingPosition = gameObject.transform.position;
        P_AudioM = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();


		if (P_VGUI = GameObject.Find("VGUI").GetComponent<VGUI>())
		{
			//Do nothing
		}
		else
		{
			Debug.Log("Could not find VGUI");
		}

    }
	
	// Update is called once per frame
	void Update ()
    {
		if (ControlManager.CM_PlayerControl)
		{
			P_Animator.SetInteger("V_Speed", (int)Input.GetAxis("Vertical"));
			P_Animator.SetInteger("H_Speed", (int)Input.GetAxis("Horizontal"));

			if (P_CanInteract)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					P_Intreactable.I_Activate();
				}
			}

		}

        Vector2 dir;
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");
        if (dir != Vector2.zero && !P_IsSliding)
        {
            if (SceneManager.GetActiveScene().name == "Winter")
            {
                if (!P_AudioM.SoundIsPlaying("WinterWalk"))
                {
                    P_AudioM.LoopSound("WinterWalk", true);
                    P_AudioM.PlaySound("WinterWalk");
                }
            }
            if (SceneManager.GetActiveScene().name == "Summer" || SceneManager.GetActiveScene().name == "Spring")
            {
                if (!P_AudioM.SoundIsPlaying("SunnyWalk"))
                {
                    P_AudioM.LoopSound("SunnyWalk", true);
                    P_AudioM.PlaySound("SunnyWalk");
                }
            }
            if (SceneManager.GetActiveScene().name == "Autumn")
            {
                if (!P_AudioM.SoundIsPlaying("AutumnWalk"))
                {
                    P_AudioM.LoopSound("AutumnWalk", true);
                    P_AudioM.PlaySound("AutumnWalk");
                }
            }
            if (SceneManager.GetActiveScene().name == "Home" || SceneManager.GetActiveScene().name == "Hub")
            {
                if (!P_AudioM.SoundIsPlaying("HubWalk"))
                {
                    P_AudioM.LoopSound("HubWalk", true);
                    P_AudioM.PlaySound("HubWalk");
                }
            }
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Winter")
            {
                P_AudioM.StopSound("WinterWalk");
            }
            if (SceneManager.GetActiveScene().name == "Summer" || SceneManager.GetActiveScene().name == "Spring")
            {
                P_AudioM.StopSound("SunnyWalk");
            }
            if (SceneManager.GetActiveScene().name == "Autumn")
            {
                P_AudioM.StopSound("AutumnWalk");
            }
            if (SceneManager.GetActiveScene().name == "Home" || SceneManager.GetActiveScene().name == "Hub")
            {
                P_AudioM.StopSound("HubWalk");
            }
        }
    }

    private void FixedUpdate()
    {
		//Debug.Log(P_CanMove);
		if (ControlManager.CM_PlayerControl)
		{
			if (!P_IsSliding)
            {
                P_SlideDir = Vector2.zero;
                HandleMovement();
            }
            else
            {
                HandleSlide();
                P_IsSliding = false;
            }
		}
    }

    private void HandleMovement()
    {
        if (P_AudioM.SoundIsPlaying("Slide"))
        {
            P_AudioM.StopSound("Slide");
        }

        Vector2 newPos;
        newPos = transform.position;
        newPos.x += Input.GetAxis("Horizontal") * P_Speed * Time.fixedDeltaTime;
        newPos.y += Input.GetAxis("Vertical") * P_Speed * Time.fixedDeltaTime;
        
        P_RigidBody.MovePosition(newPos);
    }

    private void HandleSlide()
    {
        if (!P_AudioM.SoundIsPlaying("Slide"))
        {
            P_AudioM.PlaySound("Slide");
        }

        if (P_SlideDir == Vector2.zero)
        {
            P_SlideDir.x = Input.GetAxis("Horizontal");
            P_SlideDir.y = Input.GetAxis("Vertical");
        }

        Vector2 newPos;
        newPos = transform.position;
        newPos.x += P_SlideDir.x * P_Speed * Time.fixedDeltaTime;
        newPos.y += P_SlideDir.y * P_Speed * Time.fixedDeltaTime;

        P_RigidBody.MovePosition(newPos);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
		if(col.gameObject.tag.Equals("Interactable"))
		{
			P_CanInteract = true;
			P_Intreactable = col.gameObject.GetComponent<Interactable>();
			P_VGUI.V_Interact = true;
		}
        if (col.gameObject.tag.Equals("Respawn"))
        {
            P_Respawn();
        }
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Ice"))
        {
            P_IsSliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Interactable") || col.gameObject.tag.Equals("Log"))
		{
			P_CanInteract = false;
			P_VGUI.V_Interact = false;
			P_VGUI.V_Dialogue = false;
		}
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        //Debug.Log(P_SlideDir);
        if (P_lastPos == transform.position)
        {
            P_PosTimer += Time.fixedDeltaTime;
            
            if (P_PosTimer >= 0.07f)
            {
                P_SlideDir = Vector2.zero;
            }
        }
        else
        {
            P_PosTimer = 0.0f;
        }

        P_lastPos = transform.position;
    }

    public void P_Respawn()
	{
		gameObject.transform.position = P_StartingPosition;
		Lever.L_RespawnDoor = true;
	}
}
