using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringLevel : MonoBehaviour
{

    [SerializeField] bool SPL_RiverKills;
    private Vector2 start;
    private SpriteRenderer SPL_sr;



    void Start()
    {
        SPL_RiverKills = true;
        start = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        SPL_sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Trigger") && Input.GetKey(KeyCode.E))
        {
            gameObject.layer = 11;
            SPL_RiverKills = false;
            SPL_sr.color = Color.blue;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Trigger"))
        {
            gameObject.layer = 10;
            SPL_RiverKills = true;
            SPL_sr.color = Color.white;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("River") && SPL_RiverKills == true)
        {
            gameObject.transform.position = start;
            AudioManager.instance.PlaySound("Sploosh");
        }

    }



}
