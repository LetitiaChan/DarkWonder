/***
* 
*    Title: "黑暗奇侠" 项目开发
*           
*          巨魔AI
* 
*    Description: 
*          1> 巨魔徘徊，平滑转向
*          2> 巨魔动画状态机控制
*          3> 巨魔受伤、死亡、销毁
* 
*    Version: 1.0
* 
*    Modify Recoder: 
*          1> 2017.03.17   L.T.    First Submission
* 
*/
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Troll : MonoBehaviour
{
    #region Unity Inspector Fields
    public float timer = 2f;
    public float FloSpeed = 3f;
    public float FloHealth = 10f;
    #endregion

    private CharacterController _CcTroll;
    private Animator _AniTroll;
    private bool _IsIdle = true;
    private float _FloAngle;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        _CcTroll = this.GetComponent<CharacterController>();
        _AniTroll = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (FloHealth <= 0) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (_IsIdle)
            {
                TramsformToWalk();
            }
            else
            {
                TramsformToIdle();
            }
        }

        if (!_IsIdle)
        {
            if (Mathf.Abs(_FloAngle) >= 0.2f)
            {
                float temp = _FloAngle * 0.05f;
                transform.Rotate(new Vector3(0, temp, 0));
                _FloAngle -= temp;
            }

            _CcTroll.Move((transform.forward - transform.up) * Time.deltaTime * FloSpeed);
        }
    }

    public void GetHurt(float hurtValue)
    {
        if (hurtValue > 0)
        {
            FloHealth -= hurtValue;
        }

        if (FloHealth <= 0)
        {
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        //播放死亡动画
        _AniTroll.SetFloat("death", 1.0f);
        yield return new WaitForSeconds(3f);
        //对象销毁
        Destroy(this.gameObject);
        //几率获得道具
        if (Random.Range(1, 11) > 5)
        {
            Meat.Instance.AcquireMeat(1);
        }
    }

    private void TramsformToWalk()
    {
        _IsIdle = false;
        timer = 5f;
        _FloAngle = Random.Range(-90, 90);

        AnimatorToWalk();
    }

    private void TramsformToIdle()
    {
        _IsIdle = true;
        timer = 2f;
        AnimatorToIdle();
    }

    private void AnimatorToWalk()
    {
        _AniTroll.SetFloat("run", 0f);
        _AniTroll.SetFloat("idle", 0f);
        _AniTroll.SetFloat("walk", 1.0f);
    }

    private void AnimatorToIdle()
    {
        _AniTroll.SetFloat("run", 0f);
        _AniTroll.SetFloat("idle", 1.0f);
        _AniTroll.SetFloat("walk", 0f);
    }
}
