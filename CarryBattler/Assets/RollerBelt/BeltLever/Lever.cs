using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField][Header("レバーの最大の傾き度合い")] private float MaxAngle;

    private void Start()
    {
        transform.Rotate(new Vector3(0.0f,0.0f,MaxAngle));
    }
}
