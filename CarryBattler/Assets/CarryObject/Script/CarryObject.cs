using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : ObjectBase
{
    /// <summary>
    /// ベルトコンベアの端に到達したら端の中央に乗る
    /// </summary>
    protected void OnTheGround(GameObject _Ground)
    {
        Vector3 NewPos = _Ground.transform.position;
        NewPos.y = this.transform.position.y;
        this.transform.SetPositionAndRotation(NewPos, transform.rotation);
    }
}
