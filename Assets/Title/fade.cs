using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
    public float longtaptime;
    private float taptime;
    private bool first = true;
    private bool touch = false;

    public Image me;
    public float frequency;
    private float timer;
    private bool fadein = true;
    private bool fadeout;
    private int framecount=0;


    // Start is called before the first frame update
    void Start()
    {
        me.color = new Color(0, 0, 0, 1);
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
            }else if (fadeout)
            {
                me.color += new Color(0, 0, 0, frequency * Time.deltaTime);
                if (me.color.a >= 1)
                {
                    fadeout = false;
                    SceneManager.LoadScene("myroom");
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    if (touch)
                    {
                        taptime += Time.deltaTime;
                    }
                    else
                    {
                        touch = true;
                    }
                }
                else if (touch)
                {
                    touch = false;
                    if (taptime < longtaptime)
                    {
                        first = false;
                        fadeout = true;
                    }
                    else
                    {
                        taptime = 0.0f;
                    }
                }
            }
        }
    }
}
