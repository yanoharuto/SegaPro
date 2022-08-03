using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    [SerializeField] [Header("タグ")] protected ObjectEnum.ObjectKind TagName;

    public ObjectEnum.ObjectKind ShowTagName()
    {
        return TagName;
    }
}
