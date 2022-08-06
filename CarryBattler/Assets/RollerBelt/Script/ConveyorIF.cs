using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorIF : MonoBehaviour
{
    protected BeltConveyorEnum.BeltConveyorState BCState;
    public void ChangeConveyorState(BeltConveyorEnum.BeltConveyorState _BCState)
    {
        BCState = _BCState;
    }
    public BeltConveyorEnum.BeltConveyorState ShowBCState()
    {
        return BCState;
    }
}

