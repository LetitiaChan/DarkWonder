/***
* 
*    Title: "黑暗奇侠" 项目开发
*           
*          帮助提示触发
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

public class HelpTrigger : MonoBehaviour
{
    public GameObject GoFence1;
    public GameObject GoFence2;
    public GameObject GoFence3;

    private bool _IsCrack = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_IsCrack)
        {
            Message.Instance.ShowMessage("你的力量打不开铁门，你可能\n需要借助恐龙的力量！", 4f);
        }
    }

    /// <summary>
    /// 破坏围栏
    /// </summary>
    public void DestroyFence()
    {
        if (GoFence2)
        {
            GameObject.Destroy(GoFence2);
            _IsCrack = true;
        }
        else
        {
            if (GoFence1)
                GameObject.Destroy(GoFence1);
            else
            {
                if (GoFence3)
                    GameObject.Destroy(GoFence3);
            }
        }
    }
}
