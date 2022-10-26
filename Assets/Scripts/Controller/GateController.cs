using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GateType {StickmanGate, CoalGate }

public class GateController : MonoBehaviour
{
    public GateType gateType;


    public IEnumerator ChangeGameStateCR()
    {
        GameStateEvent.Fire_OnChangeGameState(GameState.Minigame);

        yield return new WaitForSeconds(2.5f);
        GameStateEvent.Fire_OnChangeGameState(GameState.Play);
    }
}
