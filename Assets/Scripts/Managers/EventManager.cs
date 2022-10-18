using System;

public static partial class EventManager
{
    public static event Action OnBeginGame;
    public static void Fire_OnBeginGame() { OnBeginGame?.Invoke(); }

    public static event Action OnPlayGame;
    public static void Fire_OnPlayGame() { OnPlayGame?.Invoke(); }

    public static event Action OnChooseSticmanAction;
    public static void Fire_OnChooseSticmanAction() { OnChooseSticmanAction?.Invoke(); }

    public static event Action OnChooseCoalAction;
    public static void Fire_OnChooseCoalAction() { OnChooseCoalAction?.Invoke(); }

    public static event Action OnWin;
    public static void Fire_OnWin() { OnWin?.Invoke(); }

    public static event Action OnLose;
    public static void Fire_OnLose() { OnLose?.Invoke(); }

}