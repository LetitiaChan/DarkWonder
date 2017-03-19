/***
* 
*    Title: "黑暗奇侠" 项目开发
*           
*          巨魔孵化器
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

public class TrollSpawn : MonoBehaviour
{
    #region Unity Inspector Fields
    [Tooltip("巨魔预设")]
    public GameObject GoTrollPrefab;
    [Tooltip("当前巨魔数量")]
    public float FloTrollCount = 0;
    [Tooltip("最大巨魔数量")]
    public float FloMaxCount = 20;
    #endregion

    void Start()
    {
        StartCoroutine("SpawnTroll");
    }

    IEnumerator SpawnTroll()
    {
        while (FloTrollCount < FloMaxCount)
        {
            GameObject.Instantiate(GoTrollPrefab, transform.position, Quaternion.identity);
            FloTrollCount++;
            yield return new WaitForSeconds(5f);
        }
    }
}
