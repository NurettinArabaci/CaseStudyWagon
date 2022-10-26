using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectedType { Stickman, Coal }

public class Collectables : MonoBehaviour, ICollectable
{
    private enum CollectableType { Collectable, Uncollectible }
    private CollectableType collectableType;

    
    [SerializeField] CollectedType collectType;

    public void OnCollected()
    {
        if (collectableType == CollectableType.Collectable)
        {
            StackOnCarriage.Instance.GetCarriageListObject().SetActive(true);
            ScoreManager.Instance.PickUpObject(collectType);
            gameObject.SetActive(false);
        }
        else if (collectableType == CollectableType.Uncollectible)
        {
            TrainController.Instance.OnDamage(20);
            gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        EventManager.OnChoosedCoalOrStickman += OnChoosedCoalOrStickman;
    }

    void OnChoosedCoalOrStickman()
    {
        if (TrainController.Instance.trainType == TrainType.coalTrain)
        {
            if (collectType == CollectedType.Coal)
            {
                collectableType = CollectableType.Collectable;
            }

            else if (collectType == CollectedType.Stickman)
            {
                collectableType = CollectableType.Uncollectible;
            }

        }

        else if (TrainController.Instance.trainType == TrainType.peopleTrain)
        {
            if (collectType == CollectedType.Coal)
            {
                collectableType = CollectableType.Uncollectible;
            }

            else if (collectType == CollectedType.Stickman)
            {
                collectableType = CollectableType.Collectable;
            }

        }

    }

    private void OnDisable()
    {
        EventManager.OnChoosedCoalOrStickman -= OnChoosedCoalOrStickman;
    }
}

