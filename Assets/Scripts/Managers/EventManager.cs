using System;

public static partial class EventManager
{
    public static event Action OnStartGame;
    public static void Fire_OnStartGame() { OnStartGame?.Invoke(); }
}