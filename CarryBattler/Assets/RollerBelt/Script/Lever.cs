using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{
    [SerializeField] [Header("レバーの棒のRectTransform")] private RectTransform LeverStick;
    [SerializeField] [Range(0.1f, 1.0f)] [Header("スクロールバーの左右の境目")] private float BorderValue;
    [SerializeField] [Range(0.1f, 1.0f)] [Header("レバーの最大の傾き度合い")] private float MaxLeverAngle;
    [SerializeField] [Header("レバーの傾く速度")] private float LeverTiltSpeed;
    [SerializeField] [Header("スクロールバーの値でレバーが傾く")] private Scrollbar LeverScrollbar;
    private const float FirstScrollbarValue = 0.5f;
    [SerializeField] [Header("BeltConveyorの親クラス")] private ConveyorIF CIF;
    private void Start()
    {
        transform.Rotate(new Vector3(0.0f,0.0f,0.0f));
        LeverScrollbar.value = FirstScrollbarValue;
    }

    private void Update()
    {
        LeverRotate();
    }

    private void LeverRotate()
    {
        //スクロールバーの値がBorderValue分、越しているか
        if (LeverScrollbar.value > FirstScrollbarValue)
        {
            //レバーが最大角度を超していないなら
            if (LeverStick.localRotation.x < MaxLeverAngle)
            {
                LeverStick.Rotate(new Vector3(0, 0, LeverTiltSpeed));
            }
        }
        else if (LeverScrollbar.value < FirstScrollbarValue)
        {
            if (LeverStick.localRotation.x > -MaxLeverAngle)
            {
                LeverStick.Rotate(new Vector3(0, 0, -LeverTiltSpeed));
            }
        }
    }
    private void ConveyorControll()
    {

    }
}
