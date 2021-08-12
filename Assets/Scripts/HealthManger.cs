using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class HealthManger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float maxHealth;
    [SerializeField]
    float currentHealth;
    //.................

    public Slider healthSilder;
    AudioSource source;
    public AudioClip hitSound;
    public TextMeshProUGUI healthpercn;
    void Start()
    {
        healthSilder.value = currentHealth;
        source = GetComponent<AudioSource>();
        healthpercn.text = " 100 % ";
    }

    // Update is called once per frame
    void Update()
    {
        
        healthSilder.value = currentHealth;
        healthpercn.text = currentHealth % 1000 + "%";
        if (currentHealth<0)
        {
            currentHealth = 0;
        }
       if(currentHealth>100)
        {
            currentHealth = 100F;
        }

    }

    public void TakeDamage(float amount)
    {

        if(source.isPlaying==false)
        {
            source.PlayOneShot(hitSound);
        }


        currentHealth -= amount;
        healthSilder.value = currentHealth;
        if(currentHealth<=0)
        {
            Die();
        }
    }

    public void IncreaseHealth(int plus)
    {
        
        // to prvent taking health more than the maxmiumHealth;
        if(currentHealth<maxHealth)
        currentHealth +=plus;
        healthSilder.value = currentHealth;

    }

    void Die()
    {
        GetComponent<CharacterController2D>().enabled = false;
        GetComponentInChildren<Animator>().SetBool("IsDead", true);
        StartCoroutine("RestartLevel");
    }



    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
