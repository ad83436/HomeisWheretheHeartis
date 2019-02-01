using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLogs : Interactable
{
    [SerializeField] GameObject[] RL_Logs;
    void Start()
    {
        RL_Logs = GameObject.FindGameObjectsWithTag("Trigger");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void I_Activate()
    {

            RL_ResetLogs();
            Debug.Log("HI");
        
    }
      
 

    public void RL_ResetLogs()
    {
        for (int i = 0; i < RL_Logs.Length; i++)
        {
            RL_Logs[i].GetComponent<LogTrigger>().LT_Reset();
        }
    }
}
