using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retrybutton : MonoBehaviour
{
    private bool firstpush = false;
    private GameObject fadeob;
    private fade_gamescene fadecom;
    // Start is called before the first frame update
    void Start()
    {
        fadeob = GameObject.FindGameObjectWithTag("fade");
        fadecom = fadeob.GetComponent<fade_gamescene>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pushed()
    {
        if (!firstpush && !fadecom.fadeout)
        {
            firstpush = true;
            fadecom.scenename = Gmanager.instance.playingstage;
            fadecom.fadeout = true;
        }
    }
}
