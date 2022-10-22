using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainColliderController : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.TryGetComponent(out ICollectable collectable))
        {
            collectable.OnCollected();
            
        }

        else if(coll.TryGetComponent(out IAttackable attackable))
        {
            attackable.Attack(30);
        }

        else if (coll.TryGetComponent(out GateController gateController))
        {
            StartCoroutine(gateController.ChangeGameStateCR());

            if (gateController.gateType == GateType.StickmanGate) EventManager.Fire_OnChoosedStickmanGate();

            else if (gateController.gateType == GateType.CoalGate) EventManager.Fire_OnChoosedCoalGate();
        }
        else if (coll.CompareTag("Finish"))
        {
            GameStateEvent.Fire_OnChangeGameState(GameState.GameEnd);
            EventManager.Fire_OnGameEnd(transform);
        }
    }

    

    
}
