using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fade_gamescene : MonoBehaviour
{
    public Image me;
    public float frequency;
    public string scenename;
    public bool fadein;
    public bool fadeout = false;
    private int framecount = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (fadein)
        {
            me.color = new Color(0, 0, 0, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (framecount < 2)//ƒV[ƒ““Ç‚Ýž‚Ý’¼Œã‚Íˆ—‚ªd‚¢‚Ì‚Å‘Ò‚Â
        {
            framecount++;
        }
        else
        {
            if (fadein)
            {
                me.color -= new Color(0, 0, 0, frequency * Time.deltaTime);
                if (me.color.a <= 0)
                {
                    fadein = false;
                    
                }
            }
            else if (fadeout)
            {
                me.color += new Color(0, 0, 0, frequency * Time.deltaTime);
                if (me.color.a >= 1)
                {
                    fadeout = false;
                    SceneManager.LoadScene(scenename);
                }
            }
        }
    }
}