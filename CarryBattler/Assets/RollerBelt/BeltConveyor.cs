using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ベルトコンベアのベルト
/// </summary>
public class BeltConveyor : MonoBehaviour
{
    private List<GameObject> Belt = new List<GameObject>();
    [Header("ベルトが回転するスピード")] [SerializeField] private float RotationalSpeed;
     [Header("ベルトの右端の位置")] [SerializeField] private float BeltConveyorRightEdge;
     [Header("ベルトの左端の位置")] [SerializeField] private float BeltConveyorLeftEdge;
    private void Start()
    {
        for(int i=0;i<this.transform.childCount;i++)
        {
            Belt.Add(this.transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        foreach(GameObject belt in Belt)
        {
            belt.transform.position += new Vector3(RotationalSpeed, 0, 0);

            if (belt.transform.position.x > BeltConveyorRightEdge) 
            {
                belt.transform.position += new Vector3(BeltConveyorLeftEdge,0,0);
            }
        }
    }
}
