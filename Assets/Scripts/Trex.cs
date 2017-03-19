/***
* 
*    Title: "黑暗奇侠" 项目开发
*           
*          恐龙AI
* 
*    Description: 
*          1> 
* 
*    Version: 1.0
* 
*    Modify Recoder: 
*          1> 2017.03.17   L.T.    First Submission
* 
*/
using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(CharacterController))]
public class Trex : MonoBehaviour
{
    public float FloSpeed = 10f;
    public GameObject GoHelpTrigger;
    public GameObject GoTrexCamera;

    public static int IntNeedMeatCount = 10;

    private CharacterController _CcTrex;
    private string _StrCurAniName;
    private bool _IsGetControl = false;

    void Start()
    {
        _CcTrex = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_IsGetControl)
        {
            //左右控制旋转，上下控制方向
            var xOffset = Input.GetAxis("Horizontal");
            var zOffset = Input.GetAxis("Vertical");

            transform.Rotate(new Vector3(0, xOffset * 30 * Time.deltaTime, 0)); //每秒转30°
            _CcTrex.SimpleMove(transform.forward * FloSpeed * zOffset);

            //动画播放
            if (Mathf.Abs(zOffset) > 0.2f)
            {
                if (_StrCurAniName != "walk_loop")
                {
                    _StrCurAniName = "walk_loop";
                    this.GetComponent<Animation>().CrossFade("walk_loop");
                }
            }
            else
            {
                if (_StrCurAniName != "idle")
                {
                    _StrCurAniName = "idle";
                    this.GetComponent<Animation>().CrossFade("idle");
                }
            }

            //恐龙攻击
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine("Attack");
            }
        }
    }

    IEnumerator Attack()
    {
        this.GetComponent<Animation>().CrossFade("hit");
        yield return new WaitForSeconds(1.2f);
        _StrCurAniName = "idle";
        this.GetComponent<Animation>().CrossFade("idle");
    }

    public void OnTriggerStay(Collider other)
    {
        if (GoHelpTrigger && other.gameObject == GoHelpTrigger)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                other.gameObject.GetComponent<HelpTrigger>().DestroyFence();
            }
        }
    }

    public void GetControl()
    {
        print("Trex GetControl（）");
        _IsGetControl = true;
        GoTrexCamera.SetActive(true);
    }

    public void LoseControl()
    {
        print("Trex LoseControl（）");
        _IsGetControl = false;
        GoTrexCamera.SetActive(false);
    }
}
