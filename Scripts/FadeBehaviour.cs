using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeBehaviour : Interactable
{
    private Rigidbody2D FB_playerRB;
	private SpriteRenderer FB_SpriteRenderer;
	private VGUI FB_VGUI;
	private float FB_VGUITimer;
	private bool FB_StartVGUITimer;
	private Animator FB_FadeOutAnimator;
	private bool FB_InterimScreen;
	public static int FB_Counter;
	public static bool FB_Autumn = false;
	public static bool FB_Spring=false;
	public static bool FB_Summer = false;
	public static bool FB_Winter = false;
	public string FB_SceneName;
	public string FB_Title;
	public string FB_Subtitle;
	public int FB_indexInBuild;
	public Text FB_TitleText;
	public Text FB_TileSubText;
	public GameObject FB_FadeOut;


	void Start()
    {

		if(FB_SceneName == "Spring" && FB_Spring)
		{
			Destroy(gameObject);
		}
		else if(FB_SceneName == "Autumn" && FB_Autumn)
		{
			Destroy(gameObject);
		}
		else if(FB_SceneName == "Summer" && FB_Summer)
		{
			Destroy(gameObject);
		}
		else if (FB_SceneName =="Winter" && FB_Winter)
		{
			Destroy(gameObject);
		}
		
		FB_InterimScreen = false;
		FB_FadeOutAnimator = FB_FadeOut.GetComponent<Animator>();

		FB_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		if (FB_VGUI = GameObject.Find("VGUI").GetComponent<VGUI>())
		{

		}
		else
		{
			Debug.Log("Teleporter cannot find VGUI");
		}
		FB_VGUITimer = 2.0f;
		FB_StartVGUITimer = false;

		if(FB_playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>())
		{

		}
		else
		{
			Debug.Log("Fade could not find playerRB");
		}

        FB_playerRB.simulated = false;
		FB_FadeOutAnimator.SetBool("FadeOut", false);

    }

	private void Update()
	{

		if(FB_InterimScreen)
		{
			Debug.Log("Interim Screen");

			FB_TitleText.text = FB_Title;
			FB_TileSubText.text = FB_Subtitle;
			loadScene();
		}

		if (FB_Counter == 4)
		{
			if (FB_SpriteRenderer)
			{
				FB_SpriteRenderer.color = Color.white;
			}
		}

		if (FB_StartVGUITimer)
		{
			if (FB_VGUITimer > 0.0f)
			{
				FB_VGUITimer -= Time.deltaTime;
			}
			else
			{
				FB_VGUI.V_Dialogue2 = false;
				FB_StartVGUITimer = false;
				FB_VGUITimer = 2.0f;
			}
		}
	}

	public void fadeOutToScene()
    {
   
        FB_FadeOutAnimator.SetBool("FadeOut", true);
    }

    private void loadScene()
    {
        SceneManager.LoadScene(FB_indexInBuild);
    }

    public void startPlayer()
    {
		
        FB_playerRB.simulated = true;
		
    }

    public void freezePlayer()
    {
        FB_playerRB.simulated = false;
		FB_InterimScreen = true;
	}

	public override void I_Activate()
	{
		if (FB_SceneName != "Home")
		{
			fadeOutToScene();
		}
		else if (FB_SceneName == "Home" && FB_Counter == 4)
		{
			fadeOutToScene();
		}
		else
		{
			FB_StartVGUITimer = true;
			FB_VGUI.V_Dialogue2 = true;
			FB_VGUI.V_ShowThisDialogue("I can't go back yet...");
		}
	}


}
