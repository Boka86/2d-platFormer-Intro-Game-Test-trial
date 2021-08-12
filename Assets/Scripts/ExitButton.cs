using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        QuitGame();
    }

    public void QuitGame()
    {
       
        if(Input.GetKeyDown(KeyCode.Escape))
        Application.Quit();
    }

}
