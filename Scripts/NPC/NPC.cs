using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
	private VGUI N_VGUI;
	private int N_DialogueCounter;
	private string N_Dialogue;
	private SpriteRenderer N_SpriteRenderer;
	private Collider2D N_Collider;
	private bool N_ShowDialogue;
	public string N_WhichDialogue;
	public GameObject N_Smoke;
	

	private void Start()
	{
		if (N_VGUI = GameObject.Find("VGUI").GetComponent<VGUI>())
		{
			//Do nothing
		}
		else
		{
			Debug.Log("NPC Could not find VGUI");
		}

		N_DialogueCounter = 1;
		N_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		N_Collider = gameObject.GetComponent<Collider2D>();
		N_ShowDialogue = false;
	}

	private void Update()
	{
		
		if (N_ShowDialogue)
		{
			if (Input.GetKeyDown(KeyCode.N))
			{
				N_DialogueCounter++;
			}

			if (Input.GetKeyDown(KeyCode.P))
			{
				if (N_DialogueCounter > 1)
				{
					N_DialogueCounter--;
				}
			}


			switch (N_WhichDialogue)
			{
				case "Autumn":
                    if (N_DialogueCounter == 1)
                    {
                        N_Dialogue = "Oh my god are you okay?";
                    }
                    else if (N_DialogueCounter == 2)
                    {
                        N_Dialogue = "I’m so sorry those spiders came after you.";
                    }
                    else if (N_DialogueCounter == 3)
                    {
                        N_Dialogue = "By the way, you need to rake up all the leaves on the way home";
                    }
                    else if (N_DialogueCounter == 4)
                    {
                        N_Dialogue = "I don’t want to hear any complaints from you now.";
                    }
                    else
					{
                        NPC_EndDialogue();
                    }
					break;
				case "Winter":
                    if (N_DialogueCounter == 1)
                    {
                        N_Dialogue = "Holy crap! I’ve never seen you glide like that!";
                    }
                    else if (N_DialogueCounter == 2)
                    {
                        N_Dialogue = "What? Don’t tell me you didn’t have fun!";
                    }
                    else if (N_DialogueCounter == 3)
                    {
                        N_Dialogue = "It was exhilarating getting over here.";
                    }
                    else if (N_DialogueCounter == 4)
                    {
                        N_Dialogue = "It’s like you enjoy being dull.";
                    }
                    else if (N_DialogueCounter == 5)
                    {
                        N_Dialogue = "Here take this if you wanna go home the safe way.";
                    }
                    else
                    {
                        NPC_EndDialogue();
                    }
                    break;
				case "Summer":
                    if (N_DialogueCounter == 1)
                    {
                        N_Dialogue = "Hey there!";
                    }
                    else if (N_DialogueCounter == 2)
                    {
                        N_Dialogue = "Do you know how to get out of here?";
                    }
                    else if (N_DialogueCounter == 3)
                    {
                        N_Dialogue = "I think the exit is here…";
                    }
                    else if (N_DialogueCounter == 4)
                    {
                        N_Dialogue = "no there…";
                    }
                    else if (N_DialogueCounter == 5)
                    {
                        N_Dialogue = "I honestly don’t know how to get out of here.";
                    }
                    else if (N_DialogueCounter == 6)
                    {
                        N_Dialogue = "It’s okay, getting lost is just a part of the journey.";
                    }
                    else if (N_DialogueCounter == 7)
                    {
                        N_Dialogue = "I went into the forest to get your old fishing rod and I found it just over here.";
                    }
                    else if (N_DialogueCounter == 8)
                    {
                        N_Dialogue = "We should try and find our way home now.";
                    }
                    else
                    {
                        NPC_EndDialogue();
                    }
                    break;
				case "Spring":
                    if(N_DialogueCounter == 1)
                    {
                        N_Dialogue = "What took you so long?";
                    }
                    else if (N_DialogueCounter == 2)
                    {
                        N_Dialogue = "I’ve been waiting forever for you! ";
                    }
                    else if (N_DialogueCounter == 3)
                    {
                        N_Dialogue = "I’ve been stranded for a long time and I want to go home.";
                    }
                    else if (N_DialogueCounter == 4)
                    {
                        N_Dialogue = "Don’t look so tired, those logs were light.";
                    }
                    else if (N_DialogueCounter == 5)
                    {
                        N_Dialogue = "You can rest when we get home";
                    }
                    else
                    {
                        NPC_EndDialogue();
                    }
                    break;
                case "Parchment":
                    if (N_DialogueCounter == 1)
                    {
                        N_Dialogue = "I left home a year ago to live on my own. It’s been tough leaving.";
                    }
                    else if (N_DialogueCounter == 2)
                    {
                        N_Dialogue = "The only good thing I can say is that I get a break from my family.";
                    }
                    else if (N_DialogueCounter == 3)
                    {
                        N_Dialogue = "My brother, god is he impulsive.";
                    }
                    else if (N_DialogueCounter == 4)
                    {
                        N_Dialogue = "Every single time he’s trying to force me to do something. ";
                    }
                   
                    else if (N_DialogueCounter == 5)
                    {
                        N_Dialogue = "Weather it be forcing me to go out onto thin ice when we were kids,";
                    }
                    else if (N_DialogueCounter == 6)
                    {
                        N_Dialogue = "or his obsession with trying to get me into electrical engineering.";
                    }
                    else if (N_DialogueCounter == 7)
                    {
                        N_Dialogue = "My sister can be insufferable at times.";
                    }
                    else if (N_DialogueCounter == 8)
                    {
                        N_Dialogue = "She believes the entire universe revolves around her.";
                    }
                    else if (N_DialogueCounter == 9)
                    {
                        N_Dialogue = "She never has any appreciation for the people who helped her.";
                    }
                    else if (N_DialogueCounter == 10)
                    {
                        N_Dialogue = "I had to get her off an island because she decided to grab a flower";
                    }
                    else if (N_DialogueCounter == 11)
                    {
                        N_Dialogue = "and I didn't even get a thank you";
                    }
                    else if (N_DialogueCounter == 12)
                    {
                        N_Dialogue = "I hope she remembers who helped get her business off the ground.";
                    }
                    else if (N_DialogueCounter == 13)
                    {
                        N_Dialogue = " I swear my mom expects the world of me.";
                    }
                    else if (N_DialogueCounter == 14)
                    {
                        N_Dialogue = "Nothing I ever do is good enough.";
                    }
                    else if (N_DialogueCounter == 15)
                    {
                        N_Dialogue = "In grade 11, I got a 95% GPA.";
                    }
                    else if (N_DialogueCounter == 16)
                    {
                        N_Dialogue = "She asked why her dearest wasn’t trying hard enough.";
                    }
                    else if (N_DialogueCounter == 17)
                    {
                        N_Dialogue = "I rake all the leaves get rid of all the spiders";
                    }
                    else if (N_DialogueCounter == 18)
                    {
                        N_Dialogue = "and I’m not working hard enough.";
                    }
                    else if (N_DialogueCounter == 19)
                    {
                        N_Dialogue = "My father wasn’t much of a role model either.";
                    }
                    else if (N_DialogueCounter == 20)
                    {
                        N_Dialogue = "He never had any direction in his life.";
                    }
                    else if (N_DialogueCounter == 21)
                    {
                        N_Dialogue = "My father wasn’t much of a role model either.";
                    }
                    else if (N_DialogueCounter == 22)
                    {
                        N_Dialogue = "He bounced between jobs and was uncertain of his future.";
                    }
                    else if (N_DialogueCounter == 23)
                    {
                        N_Dialogue = "How do you get career advice from someone ";
                    }
                    else if (N_DialogueCounter == 24)
                    {
                        N_Dialogue = "who never had a stable career.";
                    }
                    else if (N_DialogueCounter == 25)
                    {
                        N_Dialogue = "He even got lost on a fishing trip once.";
                    }
                    else if (N_DialogueCounter == 26)
                    {
                        N_Dialogue = " I had to go through the forest to find him.";
                    }
                    else if (N_DialogueCounter == 27)
                    {
                        N_Dialogue = "Getting away from them has been a good change but…";
                    }
                    else if (N_DialogueCounter == 28)
                    {
                        N_Dialogue = "I miss them";
                    }
                    else
                    {
                        NPC_EndDialogue();
                    }
                    break;
                case "RevMom":
                    if (N_DialogueCounter == 1)
                    {
                        N_Dialogue = " I never knew you felt this way.";
                    }
                    else if (N_DialogueCounter == 2)
                    {
                        N_Dialogue = "I always assumed I was encouraging you to be the best you can be.";
                    }
                    else if (N_DialogueCounter == 3)
                    {
                        N_Dialogue = "I should have realised how much hard work you’ve put in";
                    }
                    else if (N_DialogueCounter == 4)
                    {
                        N_Dialogue = "and how much you’ve accomplished.";
                    }
                    else if (N_DialogueCounter == 5)
                    {
                        N_Dialogue = "You’re strong and capable.";
                    }
                    else if (N_DialogueCounter == 6)
                    {
                        N_Dialogue = "I love the adult you’ve grown up to be.";
                    }
                    else if (N_DialogueCounter == 7)
                    {
                        N_Dialogue = "I’m sorry";
                    }
                    else
                    {
                        NPC_EndDialogue();
                    }
                    break;
                case "RevDad":
                    if (N_DialogueCounter == 1)
                    {
                        N_Dialogue = "I know I’m not much of a role model.";
                    }
                    else if (N_DialogueCounter == 2)
                    {
                        N_Dialogue = "I’ve haven't quite figured out what job truly makes me happy yet.";
                    }
                    else if (N_DialogueCounter == 3)
                    {
                        N_Dialogue = "I want you to be your own guide and find your own future.";
                    }
                    else if (N_DialogueCounter == 4)
                    {
                        N_Dialogue = "When you find what makes you truly happy you’ll never have to worry about work.";
                    }
                    else if (N_DialogueCounter == 5)
                    {
                        N_Dialogue = "I’m sorry";
                    }
                    else
                    {
                        NPC_EndDialogue();
                    }
                    break;
                case "RevSister":
                    if (N_DialogueCounter == 1)
                    {
                        N_Dialogue = "I should’ve been more thankful for your help.";
                    }
                    else if (N_DialogueCounter == 2)
                    {
                        N_Dialogue = "I just get so wrapped up with what's happening in my life";
                    }
                    else if (N_DialogueCounter == 3)
                    {
                        N_Dialogue = "that I forgot how much you’ve helped me.";
                    }
                    else if (N_DialogueCounter == 4)
                    {
                        N_Dialogue = "I know I can be selfish, but I’m trying to change.";
                    }
                    else if (N_DialogueCounter == 5)
                    {
                        N_Dialogue = "For what it’s worth, pushing those logs to rescue me was genius.";
                    }
                    else if (N_DialogueCounter == 6)
                    {
                        N_Dialogue = "I’m sorry";
                    }
                    else
                    {
                        NPC_EndDialogue();
                    }
                    break;
                case "RevBrother":
                    if (N_DialogueCounter == 1)
                    {
                        N_Dialogue = " I never wanted you to feel like I was forcing you.";
                    }
                    else if (N_DialogueCounter == 2)
                    {
                        N_Dialogue = "I just wanted to spend time with you.";
                    }
                    else if (N_DialogueCounter == 3)
                    {
                        N_Dialogue = "I wanted you to get into electrical engineering because";
                    }
                    else if (N_DialogueCounter == 4)
                    {
                        N_Dialogue = "I wanted to be able to spend my time in university with you";
                    }
                    else if (N_DialogueCounter == 5)
                    {
                        N_Dialogue = "I’m not ready to be alone.";
                    }
                    else if (N_DialogueCounter == 6)
                    {
                        N_Dialogue = "I should let you choose your own path.";
                    }
                    else if (N_DialogueCounter == 7)
                    {
                        N_Dialogue = "I’m sorry";
                    }
                    else
                    {
                        NPC_EndDialogue();
                    }
                    break;
            }

			N_VGUI.V_ShowThisDialogue(N_Dialogue);
		}
	}

	public override void I_Activate()
	{
		N_VGUI.V_Dialogue = true;
		N_ShowDialogue = true;
		
	}

    public void NPC_EndDialogue()
    {

        N_VGUI.V_Dialogue = false;
        N_DialogueCounter = 1;
		N_ShowDialogue = false;
		if (N_WhichDialogue != "RevSister" && N_WhichDialogue != "RevBrother"
			&& N_WhichDialogue != "RevDad" && N_WhichDialogue != "RevMom" && N_WhichDialogue != "Parchment")
		{
			Smoke SmokeObject;
			SmokeObject = Instantiate(N_Smoke, gameObject.transform.position, gameObject.transform.rotation).GetComponent<Smoke>();
			SmokeObject.S_Origin = N_WhichDialogue;
			N_SpriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
			N_Collider.enabled = false;
		}
        
    }

}
