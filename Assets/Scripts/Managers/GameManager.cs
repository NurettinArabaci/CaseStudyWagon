using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Begin,
    Play,
    Stickman,
    Coal,
    Win,
    Lose
}

public static partial class GameStateEvent
{
    public static event System.Action<GameState> OnChangeGameState;
    public static void Fire_OnChangeGameState(GameState gameState) { OnChangeGameState?.Invoke(gameState); }
}

public class GameManager : MonoSingleton<GameManager>
{
    public GameState gameState;

    protected override void Awake()
    {
        base.Awake();
        GameStateEvent.OnChangeGameState += OnChangeGameState;
    }

    void OnChangeGameState(GameState newState)
    {
        gameState = newState;

        switch (newState)
        {
            case GameState.Begin:
                HandleBegin();
                break;

            case GameState.Play:
                HandlePlay();
                break;

            case GameState.Stickman:
                HandleChooseStickman();
                break;

            case GameState.Coal:
                HandleChooseCoal();
                break;

            case GameState.Win:
                HandleWin();
                break;

            case GameState.Lose:
                HandleLose();
                break;

            default:
                break;
        }
    }

    public void HandleBegin()
    {
        EventManager.Fire_OnBeginGame();
    }

    void HandlePlay()
    {
        EventManager.Fire_OnPlayGame();
    }

    void HandleChooseStickman()
    {
        EventManager.Fire_OnChooseSticmanAction();
    }

    void HandleChooseCoal()
    {
        EventManager.Fire_OnChooseCoalAction();
    }

    void HandleWin()
    {
        EventManager.Fire_OnWin();
    }

    void HandleLose()
    {
        EventManager.Fire_OnLose();
    }

    private void OnDisable()
    {
        GameStateEvent.OnChangeGameState -= OnChangeGameState;
    }
}
