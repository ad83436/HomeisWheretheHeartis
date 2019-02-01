using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SummerMaze : MonoBehaviour
{
    public GameObject Sum_Player;
    public GameObject[] Sum_Walls;
    private SpriteRenderer Sum_Switch;
    private GameObject[] Sum_TheWall;
    
  
    
    // Start is called before the first frame update
    void Start()
    {

        
        Sum_Player = GameObject.FindWithTag("Player");
        Sum_Walls = GameObject.FindGameObjectsWithTag("Wall");
        Sum_Switch = GameObject.Find("SummerSwitch").GetComponent<SpriteRenderer>();
       
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") ) 
        {
            Sum_Player.GetComponent<PlayerMovement>().P_Respawn();
            Debug.Log("Touched the log ");
        }
        if (collision.gameObject.tag.Equals("Player") && SummerSwitch.Sum_SwitchFliped)
        {
            Sum_Switch.flipX = false;
            SummerSwitch.Sum_SwitchFliped = false;
            SummerSwitch.Sum_WallTime = 0.0f;
            for (int i = 0; i < 3; ++i)
            {
                SummerSwitch.Sum_TheWall[i].GetComponent<SpriteRenderer>().enabled = true;
                SummerSwitch.Sum_TheWall[i].GetComponent<EdgeCollider2D>().enabled = true;
               
            }

            AudioManager.instance.StopSound("MazeTick");
        }
    }
}
