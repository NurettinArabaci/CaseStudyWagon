using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Carriage : MonoBehaviour, ICollectable
{
    
    [Header("CarriageObjects")]
    [SerializeField] public GameObject coalCarriage;
    [SerializeField] public GameObject peopleCarriage;

   

    public void OnCollected()
    {
        CollectableEvents.Fire_OnCollectableWithStack(this.gameObject);

    }

    public void ChangeCarriageType(GateType gateType)
    {
        switch (gateType)
        {
            case GateType.CoalGate:
                CarriageActiveInactive(coalCarriage, peopleCarriage);
                break;

            case GateType.StickmanGate:
                CarriageActiveInactive(peopleCarriage, coalCarriage);
                break;

            default:
                break;
        }
    }
    void CarriageActiveInactive(GameObject activeObject, GameObject inactiveObject)
    {
        for (int i = 0; i < 6; i++)
        {
            StackOnCarriage.Instance.AddCarriageList(activeObject.transform.GetChild(i).gameObject);
        }

        activeObject.transform.DOScale(0, 0.3f).OnComplete(() =>
        {
            activeObject.SetActive(true);
            activeObject.transform.DOScale(0.09f, 0.3f);


        });

        inactiveObject.transform.DOScale(0, 0.3f).OnComplete(() =>
        {
            inactiveObject.SetActive(false);
            inactiveObject.transform.DOScale(0.09f, 0.3f);

        });
    }

    
    


}
