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
            attackable.Attack();
        }

        else if (coll.TryGetComponent(out GateController gateController))
        {
            EventManager.Fire_OnMiniGame();
            StartCoroutine(gateController.ChangeGameStateCR());
        }
    }

    
}
