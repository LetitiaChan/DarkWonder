/***
* 
*    Title: "黑暗奇侠" 项目开发
*           
*          训练场
* 
*    Description: 
*          1> 倒计时控制
*          2> 获得技能
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

public class training : MonoBehaviour
{
    #region Unity Inspector Fields
    [Tooltip("修炼需要时长/s")]
    public float FloTimer = 30f;
    [Tooltip("技能图标")]
    public Image ImgSkill;
    #endregion

    private float _FloLeftTime;
    private bool _IsTrainingStart = false;
    private bool _IsTrainingEnd = false;
    private GameObject _GoPlayer;

    void Start()
    {
        _FloLeftTime = FloTimer;
        _IsTrainingStart = false;
        _IsTrainingEnd = false;
        ImgSkill.enabled = false;
        _GoPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (_IsTrainingStart && !_IsTrainingEnd)
        {
            _FloLeftTime -= Time.deltaTime;
            Message.Instance.ShowMessage("修炼剩余：" + _FloLeftTime.ToString("0.0") + "秒！");
            if (_FloLeftTime <= 0)
            {
                AudioManager.PlayAudioEffectA("GetTrex");
                _IsTrainingEnd = true;
                ImgSkill.enabled = true;
                Message.Instance.ShowMessage("神功修炼成功！");

                _GoPlayer.GetComponent<player>().IsGetMagic = true;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_IsTrainingEnd)
        {
            _FloLeftTime = FloTimer;
            _IsTrainingStart = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _IsTrainingStart = false;
            Message.Instance.HideMessage();
        }
    }
}
