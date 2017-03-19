/***
* 
*    Title: "黑暗奇侠" 项目开发
*           
*          胜利条件触发
* 
*    Description: 
*          1> 
* 
*    Version: 1.0
* 
*    Modify Recoder: 
*          1> 2017.03.18   L.T.    First Submission
* 
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
    public GameObject GoImgSuccess;

    private bool _IsWin = false;

    void OnGUI()
    {
        if (_IsWin)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 400, 200), "You Win!!!");
            if (GUI.Button(new Rect(Screen.width / 2 - 30, Screen.height / 2 + 50, 80, 30), "Quit"))
            {
                Application.Quit();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _IsWin = true;
            GoImgSuccess.SetActive(true);
        }
    }
}
