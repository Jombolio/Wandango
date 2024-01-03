using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    //Options Canvas
    public Canvas PauseCanvas;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseCanvas.isActiveAndEnabled)
        {
            Time.timeScale = 0;
        }
    }

    public void quitOptions()
    {
        PauseCanvas.enabled = false;   
    }

}
