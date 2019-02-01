using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VGUI : MonoBehaviour
{
	private Rect V_InteractBox;
	private Rect V_DialogueBox;
	private Rect V_DialogueControls;
	private string V_DialogueToShow;

	public bool V_Interact;
	public bool V_Dialogue;
	public bool V_Dialogue2;
	public bool V_RtoReturn;
    private GUIStyle V_Style;
   
    // Start is called before the first frame update
    void Start()
    {
		V_InteractBox = new Rect(Screen.width / 16, Screen.height / 16, Screen.width / 4, Screen.height / 12);
		V_DialogueBox  = new Rect(Screen.width/4, Screen.height / 1.4f, Screen.width / 2, Screen.height / 8);
		V_DialogueControls = new Rect(Screen.width / 2, Screen.height / 1.05f, Screen.width / 2, Screen.height / 6);
		V_Interact = false;
		V_Dialogue = false;
		V_Dialogue2 = false;
		V_RtoReturn = false;

        
    }

	void OnGUI()
	{
        V_Style = new GUIStyle(GUI.skin.box);
        V_Style.fontSize = 24;
        V_Style.fontStyle = FontStyle.Bold;
        V_Style.normal.textColor = Color.white;
        V_Style.border = new RectOffset(20, 20, 20, 20);
        V_Style.normal.background = (Texture2D)Resources.Load("Textures/BlackBox", typeof(Texture2D));
        
        if (V_Dialogue)
		{
			GUI.Box(V_DialogueBox, V_DialogueToShow,V_Style);

			V_DialogueControls = new Rect(Screen.width / 4, Screen.height / 1.1f, Screen.width / 2, Screen.height / 6);
			GUI.Label(V_DialogueControls, "P: Previous");
			V_DialogueControls = new Rect(Screen.width / 1.5f, Screen.height / 1.1f, Screen.width / 2, Screen.height / 6);
			GUI.Label(V_DialogueControls, "N: Next");
		}
		else if(V_Dialogue2)
		{
			GUI.Box(V_DialogueBox, V_DialogueToShow,V_Style);
		}
		else if (V_Interact)
		{
			GUI.Box(V_InteractBox, "Press E to Interact",V_Style);
		}
		 if(V_RtoReturn)
		{
			GUI.Box(V_InteractBox, "Press R to return", V_Style);
		}

	}

	public void V_ShowThisDialogue(string Dialog)
	{
		V_DialogueToShow = Dialog;
	}

}
