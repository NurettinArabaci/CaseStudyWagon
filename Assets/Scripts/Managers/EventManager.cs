using System;
using UnityEngine;

public static partial class EventManager
{
    public static event Action OnBeginGame;
    public static void Fire_OnBeginGame() { OnBeginGame?.Invoke(); }

    public static event Action OnPlayGame;
    public static void Fire_OnPlayGame() { OnPlayGame?.Invoke(); }

    public static event Action<Transform> OnGameEnd;
    public static void Fire_OnGameEnd(Transform transform) { OnGameEnd?.Invoke(transform); }

    public static event Action OnMiniGame;
    public static void Fire_OnMiniGame() { OnMiniGame?.Invoke(); }

    public static event Action OnWin;
    public static void Fire_OnWin() { OnWin?.Invoke(); }

    public static event Action OnLose;
    public static void Fire_OnLose() { OnLose?.Invoke(); }


    public static event Action<GateType> OnChangeCarriage;
    public static void Fire_OnChangeCarriage(GateType type) { OnChangeCarriage?.Invoke(type); }


    public static event Action OnChoosedCoalGate;
    public static void Fire_OnChoosedCoalGate() { OnChoosedCoalGate?.Invoke(); }

    public static event Action OnChoosedStickmanGate;
    public static void Fire_OnChoosedStickmanGate() { OnChoosedStickmanGate?.Invoke(); }


    public static event Action OnLowHpPanel;
    public static void Fire_OnLowHpPanel() { OnLowHpPanel?.Invoke(); }
    

}