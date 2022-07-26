using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ベルトコンベアのベルト
/// </summary>
public class BeltConveyor : MonoBehaviour
{   
    private BeltConveyorEnum.BeltConveyorState BCState; 
    private List<GameObject> Belt = new List<GameObject>();
    [Header("歯車が回転するスピード")] [SerializeField] private float RotationalGearSpeed;
    [Header("ベルトが回転するスピード")] [SerializeField] private float RotationalBeltSpeed;
    [Header("ベルトの右端の位置")] [SerializeField] private Vector3 BeltConveyorRightEdge;
    [Header("ベルトの左端の位置")] [SerializeField] private Vector3 BeltConveyorLeftEdge;

    private void Start()
    {
        for(int i=0;i<this.transform.childCount;i++)
        {
            Belt.Add(this.transform.GetChild(i).gameObject);
        }
        BCState = BeltConveyorEnum.BeltConveyorState.Left;
    }

    private void Update()
    {
        InfiniteDrive();
    }
    /// <summary>
    /// 無限駆動
    /// </summary>
    private void InfiniteDrive()
    {
        Vector3 Speed = new Vector3();

        //右か左かで進む方向を決める
        if(BCState==BeltConveyorEnum.BeltConveyorState.Left)
        {
            Speed = new Vector3(-RotationalBeltSpeed, 0, 0);
            GearControle(-RotationalGearSpeed);
        }
        if(BCState==BeltConveyorEnum.BeltConveyorState.Right)
        {
            Speed = new Vector3(RotationalBeltSpeed, 0, 0);
            GearControle(RotationalGearSpeed);
        }
        foreach (GameObject belt in Belt)
        {
            belt.transform.position += Speed;
            //端まで行ったら逆の端に移動
            if (belt.transform.position.x < BeltConveyorLeftEdge.x &&
                BCState == BeltConveyorEnum.BeltConveyorState.Left)
            {
                belt.transform.localPosition = BeltConveyorRightEdge;
            }
            else if (belt.transform.position.x > BeltConveyorRightEdge.x &&
                BCState == BeltConveyorEnum.BeltConveyorState.Right)
            {
                belt.transform.localPosition = BeltConveyorLeftEdge;
            }
        }
    }

    private void GearControle(float _RotationalGearSpeed)
    {
        foreach (GameObject belt in Belt)
        {
            Animator animator = belt.GetComponent<Animator>();
            animator.SetFloat(Animator.StringToHash("Speed"), _RotationalGearSpeed);
        }
    }
}
