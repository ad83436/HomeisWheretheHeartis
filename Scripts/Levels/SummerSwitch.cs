using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerSwitch : Interactable
{
    public static GameObject[] Sum_TheWall;
    public static bool Sum_SwitchFliped;
    public static float Sum_WallTime = 0.0f;
    public bool Sum_PlayerMetNPC;
    private GameObject Sum_Player;
    public SpriteRenderer Sum_Switch;
    public AudioManager Sum_AudioM;

    // Start is called before the first frame update
    void Start()
    {
        Sum_TheWall = GameObject.FindGameObjectsWithTag("TheWall");
        Sum_SwitchFliped = false;
        Sum_PlayerMetNPC = false;
        Sum_Player = GameObject.FindWithTag("Player");
        Sum_Switch = GameObject.Find("SummerSwitch").GetComponent<SpriteRenderer>();
        Sum_AudioM = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Sum_SwitchFliped)
        {
            Sum_WallTime += Time.deltaTime;
        }
        if (Sum_WallTime > 27.0f)
        {
            Sum_Switch.flipX = false;
            Sum_SwitchFliped = false;
            Sum_Player.GetComponent<SpriteRenderer>().color = Color.red;
            Sum_WallTime = 0;
            for(int i = 0; i < 3; ++i)
            {
                Sum_TheWall[i].GetComponent<SpriteRenderer>().enabled = true;
                Sum_TheWall[i].GetComponent<EdgeCollider2D>().enabled = true;
            }

            Sum_AudioM.StopSound("MazeTick");
            Sum_AudioM.PlaySound("Ding");

        }

        
    }

    public override void I_Activate()
    {
        Sum_Switch.flipX = true;
        Sum_SwitchFliped = true;
        Sum_Player.GetComponent<SpriteRenderer>().color = Color.white;
        for (int i = 0; i < 3; ++i)
        {
            Sum_TheWall[i].GetComponent<SpriteRenderer>().enabled = false;
            Sum_TheWall[i].GetComponent<EdgeCollider2D>().enabled = false;
        }
        Sum_AudioM.PlaySound("FlipLever");
        Sum_AudioM.LoopSound("MazeTick", true);
        Sum_AudioM.PlaySound("MazeTick");
    }

}
    
