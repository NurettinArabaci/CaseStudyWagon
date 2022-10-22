using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType { Collectable, Uncollectible}
public class Coal : MonoBehaviour, ICollectable
{
    public CollectableType collectableType;

    public void OnCollected()
    {
        if (collectableType == CollectableType.Collectable)
        {
            StackOnCarriage.Instance.GetCarriageListObject().SetActive(true);
            ScoreManager.Instance.PickUpObject(null, this);
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
        collectableType = CollectableType.Collectable;
    }

    void OnChoosedStickmanGate()
    {
        collectableType = CollectableType.Uncollectible;
    }

    private void OnDisable()
    {
        EventManager.OnChoosedCoalGate -= OnChoosedCoalGate;
        EventManager.OnChoosedStickmanGate -= OnChoosedStickmanGate;
    }

}