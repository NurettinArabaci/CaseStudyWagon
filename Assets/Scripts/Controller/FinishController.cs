using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishController : MonoBehaviour
{
    [SerializeField] Transform gameEndFirstPoint;
    [SerializeField] Transform gameEndSecondPoint;

    private void Awake()
    {
        EventManager.OnGameEnd += OnGameEnd;
    }

    void OnGameEnd(Transform _transform)
    {
        _transform.DOMove(gameEndFirstPoint.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
        _transform.DOMove(gameEndSecondPoint.position,1.5f).OnComplete(()=>
        GameStateEvent.Fire_OnChangeGameState(GameState.Win)));
    }



    private void OnDisable()
    {
        EventManager.OnGameEnd -= OnGameEnd;
    }
}
