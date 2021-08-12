using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Increase : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthIncrease;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")||collision.gameObject.CompareTag("inPowerUpMode"))
        {

            collision.gameObject.GetComponent<CharacterController2D>().HealthSound();
            collision.gameObject.GetComponent<HealthManger>().IncreaseHealth(healthIncrease);
            Destroy(gameObject);
        }
    }
}
