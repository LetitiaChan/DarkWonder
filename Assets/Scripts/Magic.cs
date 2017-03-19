/***
* 
*    Title: "黑暗奇侠" 项目开发
*           
*          魔法技能相关逻辑
* 
*    Description: 
*          1> 技能释放
*          2> 技能伤害
*          3> 技能销毁
* 
*    Version: 1.0
* 
*    Modify Recoder: 
*          1> 2017.03.17   L.T.    First Submission
* 
*/
using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour
{
    #region Unity Inspector Fields
    [Tooltip("魔法攻击力")]
    public float FloATKValue = 1f;
    #endregion

    //方式1
    IEnumerator Start()
    {
        yield return new WaitForSeconds(7f);
        Destroy(this.gameObject);
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Troll>().GetHurt(FloATKValue * Time.deltaTime);
        }
    }
}
