using UnityEngine;
using System.Collections;

public class Wonder : Building
{
    //nothing special to specify

    protected override bool ShouldMakeDecision()
    {
        return false;
    }
}