/***
* 
*    Title: "黑暗奇侠" 项目开发
*           
*          开始场景对话框
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

public class ShowDialog : MonoBehaviour
{
    public Sprite[] ArrImgDialog;

    private int _IntCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_IntCount == 10)
            {
                Application.LoadLevel("game");
            }
            else
            {
                GetComponent<Image>().sprite = ArrImgDialog[_IntCount];
                _IntCount++;
            }
        }
    }
}
