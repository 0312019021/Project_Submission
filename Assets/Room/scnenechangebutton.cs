using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scnenechangebutton : MonoBehaviour
{
    private GameObject fadeob;
    private fade_gamescene fadecom;
    private bool firstpush = false;

    public string scenename;
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

    public void scenechange()
    {
        if (!firstpush&&!fadecom.fadeout)
        {
            firstpush = true;
            fadecom.scenename = this.scenename;
            fadecom.fadeout = true;
        }
    }
}
