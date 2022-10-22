using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour ,ICollectable
{
    public CollectableType collectableType;

    public void OnCollected()
    {
        if (collectableType==CollectableType.Collectable)
        {
            StackOnCarriage.Instance.GetCarriageListObject().SetActive(true);
            ScoreManager.Instance.PickUpObject(this);
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
        EventManager.OnChoosedCoalGate += OnChoosedCoalGate;
        EventManager.OnChoosedStickmanGate += OnChoosedStickmanGate;
    }

    void OnChoosedCoalGate()
    {
        collectableType = CollectableType.Uncollectible;
    }

    void OnChoosedStickmanGate()
    {
        collectableType = CollectableType.Collectable;
    }

    private void OnDisable()
    {
        EventManager.OnChoosedCoalGate -= OnChoosedCoalGate;
        EventManager.OnChoosedStickmanGate -= OnChoosedStickmanGate;
    }


}
