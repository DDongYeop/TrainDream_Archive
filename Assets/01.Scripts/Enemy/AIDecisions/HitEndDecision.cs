using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEndDecision : AIDecision
{
    public override bool MakeADecision()
    {
        return !_aiActionData.IsHitting;
    }
}
