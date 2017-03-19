/***
* 
*    Title: "黑暗奇侠" 项目开发
*           
*          主角控制
* 
*    Description: 
*          1> 
* 
*    Version: 1.0
* 
*    Modify Recoder: 
*          1> 2017.03.15   L.T.    First Submission
* 
*/
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class player : MonoBehaviour
{
    #region Unity Inspector Fields
    [Tooltip("移动速度")]
    public float FloSpeed = 10F;
    [Tooltip("是否获得魔法")]
    public bool IsGetMagic = false;
    [Tooltip("释放魔法特效预设")]
    public GameObject GoMagicPrefab;

    public GameObject GoMainCamera;
    public Trex TrexScript;
    #endregion

    private float timer = 1f;
    private float _FloTimerReset;
    private CharacterController _CtController;
    private bool _IsNearTrex = false;
    private bool _IsGetControlTrex = false;
    private bool _IsGetControl = true;

    void Start()
    {
        _CtController = this.GetComponent<CharacterController>();
        _FloTimerReset = timer;

        AudioManager.AudioBackgroundVolumns = 0.5f;
        AudioManager.AudioEffectVolumns = 1f;
        AudioManager.PlayBackground("bg");
    }

    void Update()
    {
        if (_IsGetControl)
        {
            _CtController.SimpleMove(new Vector3(Input.GetAxis("Horizontal") * FloSpeed, 0, Input.GetAxis("Vertical") * FloSpeed));

            if (IsGetMagic)
            {
                timer -= Time.deltaTime;
                if (Input.GetButtonDown("Fire1") && timer <= 0)
                {
                    timer = _FloTimerReset;
                    GameObject.Instantiate(GoMagicPrefab, transform.position, Quaternion.identity);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_IsGetControl && _IsGetControlTrex)
            {
                AudioManager.PlayAudioEffectA("GetTrex");
                TrexScript.SendMessage("GetControl");
                this.LoseControl();
            }
            else if (!_IsGetControl && _IsGetControlTrex)
            {
                AudioManager.PlayAudioEffectA("GetTrex");
                TrexScript.SendMessage("LoseControl");
                this.GetControl();
            }
        }
    }

    void OnGUI()
    {
        if (_IsNearTrex && !_IsGetControlTrex)
        {
            ShowDialog();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trex")
        {
            _IsNearTrex = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Trex")
        {
            _IsNearTrex = false;
        }
    }

    private void ShowDialog()
    {
        if (Meat.Instance.IntMeatCount <= 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 125, Screen.height / 2, 250, 100), "恐龙非常饿，你是否愿意给恐龙找吃的？");
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 125, Screen.height / 2, 250, 100), "是否把身上的巨魔肉喂给恐龙？");
            bool yes = GUI.Button(new Rect(Screen.width / 2 - 70 - 40, Screen.height / 2 + 30, 70, 30), "是");
            bool no = GUI.Button(new Rect(Screen.width / 2 + 70 - 40, Screen.height / 2 + 30, 70, 30), "否");
            if (yes)
            {
                Meat.Instance.UseMeat();
                if (Trex.IntNeedMeatCount <= 0)
                {
                    _IsGetControlTrex = true;
                    Message.Instance.ShowMessage("你已经获得了恐龙的信任，现在可以控制恐龙，使用Q键进行控制切换！", 6);
                }
                _IsNearTrex = false;
            }
            if (no)
            {
                _IsNearTrex = false;
            }
        }
    }

    private void GetControl()
    {
        _IsGetControl = true;
        GoMainCamera.SetActive(true);
    }

    private void LoseControl()
    {
        _IsGetControl = false;
        GoMainCamera.SetActive(false);
    }
}
