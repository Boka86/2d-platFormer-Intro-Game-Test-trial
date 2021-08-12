using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LethalScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float damage;
    public bool push;
    [SerializeField]
    float pushForce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
      if (collision.gameObject.tag==("Player"))
        {

            collision.gameObject.GetComponent<HealthManger>().TakeDamage(damage);
            Debug.Log(" i hit Player ");
            if(push)
            {
                Vector2 pushDirection = collision.transform.position - transform.position;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection.normalized*pushForce);
            }
        }
    }
    
   
}
