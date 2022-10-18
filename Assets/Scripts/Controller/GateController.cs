using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GateType {StickmanGate, CoalGate }

public class GateController : MonoBehaviour
{
    public GateType gateType;

    private void Awake()
    {
        SubscribeEvents();
    }

    void OnChooseSticmanAction()
    {

    }

    void OnChooseCoalAction()
    {

    }


    #region EventsSubsAction

    void SubscribeEvents()
    {
        switch (gateType)
        {
            case GateType.StickmanGate:
                EventManager.OnChooseSticmanAction += OnChooseSticmanAction;
                break;

            case GateType.CoalGate:
                EventManager.OnChooseCoalAction += OnChooseCoalAction;
                break;

            default:
                break;
        }
    }
    void UnSubscribeEvents()
    {
        switch (gateType)
        {
            case GateType.StickmanGate:
                EventManager.OnChooseSticmanAction -= OnChooseSticmanAction;
                break;

            case GateType.CoalGate:
                EventManager.OnChooseCoalAction -= OnChooseCoalAction;
                break;

            default:
                break;
        }
    }
    #endregion

    private void OnDisable()
    {
        UnSubscribeEvents();
    }
}
