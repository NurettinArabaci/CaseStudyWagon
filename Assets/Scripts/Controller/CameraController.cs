using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraController : MonoSingleton<CameraController>
{
    [SerializeField] CinemachineVirtualCamera initCam;
    [SerializeField] CinemachineVirtualCamera playCam;
    [SerializeField] CinemachineVirtualCamera gameEndCam;

    //Vector3 offset = new Vector3(0, 0.2f, -1.25f);
    Vector3 offset = new Vector3(0, 0.1f, -0.8f);

    protected override void Awake()
    {
        base.Awake();

        EventManager.OnBeginGame += OnStartGame;
        EventManager.OnPlayGame += OnPlayCam;
        EventManager.OnWin += OnGameEndCam;
    }

   

    private void Start()
    {
        OnStartGame();
    }

    public void OnStartGame()
    {
        initCam.m_Priority = 10;
        playCam.m_Priority = 9;
        gameEndCam.m_Priority = 9;
    }

    public void OnPlayCam()
    {
        playCam.m_Priority = 11;
    }

    public void OnGameEndCam()
    {
        gameEndCam.m_Priority = 12;
    }

    public void CamGoBackOnStack()
    {
        var transposer = playCam.GetCinemachineComponent<CinemachineTransposer>();
        DOTween.To(() => transposer.m_FollowOffset, x => transposer.m_FollowOffset = x, transposer.m_FollowOffset + offset, 1f);
        
    }

    private void OnDisable()
    {
        EventManager.OnBeginGame -= OnStartGame;
        EventManager.OnPlayGame -= OnPlayCam;
        EventManager.OnWin -= OnGameEndCam;
    }

}
