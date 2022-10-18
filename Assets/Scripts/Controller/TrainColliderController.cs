using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainColliderController : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        if (TryGetComponent(out ICollectable collectable))
        {
            collectable.OnCollected();
            
        }

        else if(TryGetComponent(out IAttackable attackable))
        {
            attackable.Attack();
        }

        else if (TryGetComponent(out GateController gateController))
        {
            if (gateController.gateType == GateType.StickmanGate)
                GameStateEvent.Fire_OnChangeGameState(GameState.Stickman);

            else if (gateController.gateType == GateType.CoalGate)
                GameStateEvent.Fire_OnChangeGameState(GameState.Coal);
        }
    }
}
