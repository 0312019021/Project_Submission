using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animationmanager : MonoBehaviour
{
    public SpriteRenderer avatar;
    public Animator avataranim;
    public SpriteRenderer headset;
    public Animator headsetanim;
    public GameObject mask;
    public Text reloading;
    public GameObject textob;
    public float headsetblink;
    public float headsetblinktime;
    public float avatarblink;
    public float avatarblinktime;
    public float maskspeed;
    public float maskresetpos;

    public float directionstarttime;
    public float direction2starttime;
    public float direction3starttime;
    public float directionendtime;
    public float textupdatefrequency;
    public float textblink;
    public float textblinktime;
    public float textfadeoutfrequency;

    public float awakefrequency;

    public float timecorrection;
    //*timecorrection*Time.deltaTime フレームレートによる挙動の差をなくすため


    private float headsetblinkcount=0.0f;
    private float avatarblinkcount=0.0f;
    private float directioncount=0.0f;
    private bool indirection = false;
    private bool indirection2 = false;
    private bool indirection3 = false;
    private int textcount=0;
    private float textupdatecount=0.0f;
    private float textblinkcount=0.0f;
    private int blinknum=0;

    private Vector3 maskinitialpos;
    private Color textinitialcolor;
    private Color avatarinitialcolor;
    private Color headsetinitialcolor;
    // Start is called before the first frame update
    void Start()
    {
        maskinitialpos = mask.transform.position;
        textinitialcolor = reloading.color;
        avatarinitialcolor = avatar.color;
        headsetinitialcolor = headset.color;
    }

    // Update is called once per frame
    void Update()
    {
        directioncount += Time.deltaTime;
        if (directioncount > directionstarttime && !indirection)//特殊演出開始
        {
            avataranim.SetTrigger("error");
            headsetanim.SetTrigger("error");
            mask.SetActive(false);
            indirection = true;
        }
        else if(directioncount > direction2starttime&&!(directioncount > direction3starttime))//演出2
        {
            //数値初期化
            if (!indirection2)
            {
                indirection2 = true;
                textob.SetActive(true);
                reloading.color = textinitialcolor;
                textcount = 1;
                reloading.text = ("Reloading");
            }

            //テキストを更新し続ける
            textupdatecount += Time.deltaTime;
            if (textupdatecount > textupdatefrequency)
            {
                textupdatecount = 0.0f;
                textcount += 1;
                switch (textcount)
                {
                    case 1: reloading.text = ("Reloading"); break;
                    case 2: reloading.text += ("."); break;
                    case 3: reloading.text += ("."); break;
                    case 4: reloading.text += ("."); textcount = 0; break;
                    default: break;
                }
            }

            //明滅処理
            textblinkcount += Time.deltaTime;
            if (textblinkcount > textblinktime * 2)
            {
                textblinkcount = 0.0f;
            }
            if (textblinkcount > textblinktime)
            {
                reloading.color += new Color(0, 0, 0, textblink * timecorrection * Time.deltaTime);
            }
            else
            {
                reloading.color -= new Color(0, 0, 0, textblink * timecorrection * Time.deltaTime);
            }
        }else if (directioncount> direction3starttime&&!(directioncount > directionendtime))//演出3
        {
            if (!indirection3)
            {
                indirection3 = true;
                reloading.color = textinitialcolor;
                reloading.text = ("Complete");
                avataranim.SetTrigger("idle");
                avatar.color = new Color(1,1,1,0);
                headsetanim.SetTrigger("idle");
                headset.color = new Color(1, 1, 1, 0);
            }
            if (blinknum == 0)
            {
                avatar.color += new Color(0, 0, 0, awakefrequency * timecorrection * Time.deltaTime);
                headset.color += new Color(0, 0, 0, awakefrequency * timecorrection * Time.deltaTime);
                if (avatar.color.a>avatarinitialcolor.a)
                {
                    blinknum = 1;
                }
            }else if (blinknum == 1)
            {
                avatar.color -= new Color(0, 0, 0, awakefrequency/2 * timecorrection * Time.deltaTime);
                headset.color -= new Color(0, 0, 0, awakefrequency/2 * timecorrection * Time.deltaTime);
                if(avatar.color.a < avatarinitialcolor.a / 2)
                {
                    blinknum = 2;
                }
            }else if (blinknum == 2)
            {
                avatar.color += new Color(0, 0, 0, awakefrequency / 2 * timecorrection * Time.deltaTime);
                headset.color += new Color(0, 0, 0, awakefrequency / 2 * timecorrection * Time.deltaTime);
                if (avatar.color.a > avatarinitialcolor.a)
                {
                    blinknum = 3;
                    avatar.color = avatarinitialcolor;
                    headset.color = headsetinitialcolor;
                }
            }else if (blinknum == 3)
            {
                reloading.color -= new Color(0,0,0, textfadeoutfrequency * timecorrection * Time.deltaTime);
            }
            

        }
        else if (directioncount > directionendtime)//演出終わり
        {
            avatar.color = avatarinitialcolor;
            headset.color = headsetinitialcolor;
            mask.SetActive(true);
            mask.transform.position = maskinitialpos;
            textob.SetActive(false);
            blinknum = 0;
            indirection = false;
            indirection2 = false;
            indirection3 = false;
            directioncount = 0.0f;
        }
        else//平常時
        {
            //手前キャラの明滅処理
            avatarblinkcount += Time.deltaTime;
            if (avatarblinkcount > avatarblinktime * 2)
            {
                avatarblinkcount = 0.0f;
            }
            if (avatarblinkcount > avatarblinktime)
            {
                avatar.color += new Color(0, 0, 0, avatarblink * timecorrection * Time.deltaTime);
            }
            else
            {
                avatar.color -= new Color(0, 0, 0, avatarblink * timecorrection * Time.deltaTime);
            }

            //ヘッドセットの明滅処理
            headsetblinkcount += Time.deltaTime;
            if (headsetblinkcount > headsetblinktime * 2)
            {
                headsetblinkcount = 0.0f;
            }
            if (headsetblinkcount > headsetblinktime)
            {
                headset.color += new Color(0, 0, 0, headsetblink * timecorrection * Time.deltaTime);
            }
            else
            {
                headset.color -= new Color(0, 0, 0, headsetblink * timecorrection * Time.deltaTime);
            }

            //mask線の移動処理
            mask.transform.position -= new Vector3(0, maskspeed * timecorrection * Time.deltaTime, 0);
            if (mask.transform.position.y < maskresetpos)
            {
                mask.transform.position = maskinitialpos;
            }
        }


    }
}
