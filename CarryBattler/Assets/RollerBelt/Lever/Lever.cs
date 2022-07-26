using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{
    [SerializeField][Header("レバーの最大の傾き度合い")] private float MaxAngle;
    [SerializeField][Header("ユーザーが操作するために必要なUI")] private Scrollbar LeverScrollbar;
    [SerializeField] [Header("スクロールバーの左右に向く境目")] private float BorderValue;
    private void Start()
    {
        transform.Rotate(new Vector3(0.0f,0.0f,0.0f));
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, LeverScrollbar.value));
    }
}
