using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{
    [SerializeField] [Header("レバーの棒のRectTransform")] private RectTransform LeverStick;
    [SerializeField] [Range(0.001f, 0.5f)] [Header("スクロールバーの左右の境目")] private float BorderValue;
    [SerializeField] [Range(0.1f, 1.0f)] [Header("レバーの最大の傾き度合い")] private float MaxLeverAngle;
    [SerializeField] [Header("レバーの傾く速度")] private float LeverTiltSpeed;
    [SerializeField] [Header("スクロールバーの値でレバーが傾く")] private Scrollbar Scrollbar;
    private const float FirstScrollbarValue = 0.5f;
    [SerializeField] [Header("BeltConveyorの親クラス")] private ConveyorIF CIF;
    private bool IsCloseCenterLeverStick; //レバー棒が中央に近いかどうか

    //初期化
    private void Start()
    {
        transform.Rotate(new Vector3(0.0f,0.0f,0.0f));
        Scrollbar.value = FirstScrollbarValue;
        IsCloseCenterLeverStick = true;
    }

    private void Update()
    {
        LeverRotate();
        LeverCollection();
        ConveyorControll();
    }
    /// <summary>
    /// レバー棒を傾けさせるよ
    /// </summary>
    private void LeverRotate()
    {
        //スクロールバーの値が真ん中より右か
        if (Scrollbar.value > FirstScrollbarValue)
        {
            LeverStick.Rotate(new Vector3(0, 0, LeverTiltSpeed));
            Debug.Log(Scrollbar.value);
        }
        //スクロールバーの値が真ん中より左か
        else if (Scrollbar.value < FirstScrollbarValue)
        {
            LeverStick.Rotate(new Vector3(0, 0, -LeverTiltSpeed));
            Debug.Log(Scrollbar.value);
        }
        //レバー棒が真ん中付近に来たか
        if (LeverStick.rotation.x < BorderValue && LeverStick.rotation.x > -BorderValue) 
        {
            IsCloseCenterLeverStick = true;
        }
        else
        {
            IsCloseCenterLeverStick = false;
        }
    }
    /// <summary>
    /// レバーのスティックが行き過ぎていたら補正する
    /// </summary>
    private void LeverCollection()
    {
        //修正した後の角度
        Quaternion CollectionStickRota = LeverStick.rotation;
        //レバー棒が右に行き過ぎでスクロールバーが右寄りの時
        if (LeverStick.rotation.x > MaxLeverAngle &&
            Scrollbar.value > FirstScrollbarValue)
        {
            CollectionStickRota.x = MaxLeverAngle;
        }
        //レバー棒が左に行き過ぎたでスクロールバーが左寄りの時
        else if (LeverStick.rotation.x < -MaxLeverAngle &&
            Scrollbar.value < FirstScrollbarValue)
        {
            CollectionStickRota.x = -MaxLeverAngle;
        }
        //レバー棒が真ん中付近に来ていてスクロールバーが中央寄りのとき
        else if (IsCloseCenterLeverStick &&
            (Scrollbar.value < FirstScrollbarValue + BorderValue && Scrollbar.value > FirstScrollbarValue - BorderValue) )
        {
            CollectionStickRota.x = 0;
        }    
        //レバー棒の角度を修正するときの角度
        LeverStick.SetPositionAndRotation(LeverStick.position, (CollectionStickRota));
    }

    /// <summary>
    /// ベルトコンベアにどの方向に動くか命令する
    /// </summary>
    private void ConveyorControll()
    {
        if (LeverStick.rotation.x >= MaxLeverAngle)
        {
            CIF.ChangeConveyorState(BeltConveyorEnum.BeltConveyorState.Right);
        }
        else if (LeverStick.rotation.x <= -MaxLeverAngle)
        {
            CIF.ChangeConveyorState(BeltConveyorEnum.BeltConveyorState.Left);
        }
        else if (IsCloseCenterLeverStick)
        {
            CIF.ChangeConveyorState(BeltConveyorEnum.BeltConveyorState.Stop);
        }
    }
}
