using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SpinButton : MonoBehaviour
{
    public RouletteSpin spin;

    public void EnableSpin()
    {
        spin.enabled = true;
    }
}
