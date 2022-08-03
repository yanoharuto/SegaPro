using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : ObjectBase
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if(gameObject.GetComponent<ObjectBase>().ShowTagName()==ObjectEnum.ObjectKind.Ground)
        {
            OnTheGround(gameObject);
        }
    }

    /// <summary>
    /// ベルトコンベアの端に到達したら端の中央に乗る
    /// </summary>
    private void OnTheGround(GameObject ground)
    {
        this.transform.SetPositionAndRotation(ground.transform.position,this.transform.rotation);
    }
}
