using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShakeController : MonoSingleton<CameraShakeController>
{
    [SerializeField]CinemachineImpulseSource source;

    protected override void Awake()
    {
        base.Awake();
    }
    public void ShakeCam()
    {
        source.GenerateImpulse();
    }
}
