using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public float activeTime;
    public float level;
    public bool alwaysActive;
    public KeyCode key;
    public virtual void Activate()
    {

    }
}
