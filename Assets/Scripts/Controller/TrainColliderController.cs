using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainColliderController : MonoBehaviour
{
    [SerializeField] TrainController trainController;

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

            EventManager.Fire_OnChoosedCoalOrStickman();

            if (gateController.gateType == GateType.StickmanGate) trainController.trainType=TrainType.peopleTrain;

            else if (gateController.gateType == GateType.CoalGate) trainController.trainType = TrainType.coalTrain;
        }
        else if (coll.CompareTag("Finish"))
        {
            GameStateEvent.Fire_OnChangeGameState(GameState.GameEnd);
            EventManager.Fire_OnGameEnd(transform);
        }
    }

    

    
}
