using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelOil : MonoBehaviour, ICollectable
{
    public void OnCollected()
    {
        TrainController.Instance.FuelOilIncrease();
        CollectableEvents.Fire_OnShakeOnStack();
        gameObject.SetActive(false);
    }
}
