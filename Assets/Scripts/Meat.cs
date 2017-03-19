/***
* 
*    Title: "黑暗奇侠" 项目开发
*           
*          巨魔肉相关逻辑
* 
*    Description: 
*          1> 巨魔肉的获取
*          2> 巨魔肉的使用
* 
*    Version: 1.0
* 
*    Modify Recoder: 
*          1> 2017.03.17   L.T.    First Submission
* 
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Meat : MonoBehaviour
{
    public static Meat Instance;
    public Text TxtMeatCount;

    public int IntMeatCount = 0;

    void Start()
    {
        Instance = this;
        gameObject.SetActive(false);
        TxtMeatCount.enabled = false;
    }

    /// <summary>
    /// 获得巨魔肉
    /// </summary>
    /// <param name="num"></param>
    public void AcquireMeat(int num)
    {
        AudioManager.PlayAudioEffectA("GetMeat");
        IntMeatCount += num;
        if (IntMeatCount > 0)
        {
            gameObject.SetActive(true);
            TxtMeatCount.text = IntMeatCount + "";
            TxtMeatCount.enabled = true;
        }
    }

    /// <summary>
    /// 使用巨魔肉
    /// </summary>
    public void UseMeat()
    {
        Trex.IntNeedMeatCount -= IntMeatCount;
        IntMeatCount = 0;
        gameObject.SetActive(false);
        TxtMeatCount.text = IntMeatCount + "";
        TxtMeatCount.enabled = false;
    }
}
