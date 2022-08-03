using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : ObjectBase
{
    protected void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        Debug.Log("attata");
        if(gameObject.GetComponent<ObjectBase>().ShowTagName()==ObjectEnum.ObjectKind.Ground)
        {
            OnTheGround(gameObject);
        }
    }

    /// <summary>
    /// ベルトコンベアの端に到達したら端の中央に乗る
    /// </summary>
    private void OnTheGround(GameObject _Ground)
    {
        Vector3 NewPos = _Ground.transform.position;
        NewPos.y = this.transform.position.y;
        this.transform.SetPositionAndRotation(NewPos, transform.rotation);
    }
}
