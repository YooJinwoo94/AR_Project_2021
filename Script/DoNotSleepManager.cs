using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotSleepManager : MonoBehaviour
{
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
