using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishController : MonoBehaviour
{
    [SerializeField] Transform gameEndFirstPoint;

    private void Awake()
    {
        EventManager.OnGameEnd += OnGameEnd;
    }

    void OnGameEnd(Transform _transform)
    {

        CollectableEvents.Fire_OnMovementLerp();
        _transform.DOMove(gameEndFirstPoint.position, 2.5f).OnComplete(() =>
        GameStateEvent.Fire_OnChangeGameState(GameState.Win));
    }



    private void OnDisable()
    {
        EventManager.OnGameEnd -= OnGameEnd;
    }
}
