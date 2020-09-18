using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;
using TinyBitTurtle.Toolkit;

public class  ActionCtrl : SingletonMonoBehaviour<ActionCtrl>
{
    public void DebugOutput(string actionName) { Debug.LogError(CRC32.Compute(actionName) + "/*" + actionName + "*/");}
}