using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTrigger : Interactable {

    // Use this for initialization

    private Rigidbody2D LT_rb;
    public bool LT_ResetBool;
    private Vector2 LT_StartPos;
    private Transform LT_ParentPos;
    private GameObject LT_Parent;
    
	void Start ()
    {
        LT_rb = gameObject.GetComponentInParent<Rigidbody2D>();
        LT_ParentPos = gameObject.GetComponentInParent<Transform>();
        LT_StartPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        LT_ResetBool = false;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
       
    }

   

    public void LT_Reset()
    {
        
        LT_ParentPos.transform.parent.position= LT_StartPos;
        LT_ResetBool = false;
        
        
    }

    

    
}
