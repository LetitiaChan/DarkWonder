/***
* 
*    Title: "黑暗奇侠" 项目开发
*           
*          一般系统消息的显示控制
* 
*    Description: 
*          1> 
* 
*    Version: 1.0
* 
*    Modify Recoder: 
*          1> 2017.03.16   L.T.    First Submission
* 
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Message : MonoBehaviour
{
    public static Message Instance;
    private Text _TxtMessage;
    private float _FloDuration = 0f;

    void Start()
    {
        Instance = this;
        _TxtMessage = this.gameObject.GetComponent<Text>();
    }

    /// <summary>
    /// 显示消息
    /// </summary>
    /// <param name="txt"></param>
    public void ShowMessage(string txt)
    {
        _TxtMessage.text = txt;
        _TxtMessage.enabled = true;
    }

    /// <summary>
    /// 显示提示消息
    /// </summary>
    /// <param name="txt"></param>
    /// <param name="timer"></param>
    public void ShowMessage(string txt, float timer)
    {
        _TxtMessage.text = txt;
        _TxtMessage.enabled = true;
        _FloDuration = timer;
        StartCoroutine("ShowMsgByTime");
    }

    IEnumerator ShowMsgByTime()
    {
        yield return new WaitForSeconds(_FloDuration);
        HideMessage();
    }

    /// <summary>
    /// 隐藏消息
    /// </summary>
    public void HideMessage()
    {
        _TxtMessage.enabled = false;
    }

}
