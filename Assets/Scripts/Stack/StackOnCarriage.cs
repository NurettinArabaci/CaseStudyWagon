using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackOnCarriage : MonoSingleton<StackOnCarriage>
{
    [SerializeField]private List<GameObject> objectsInCarriage = new List<GameObject>();
    public int objectsInCarriageID = -1;

    protected override void Awake()
    {
        base.Awake();
    }

    public void AddCarriageList(GameObject gO)
    {
        objectsInCarriage.Add(gO);
    }
    public GameObject GetCarriageListObject()
    {
        objectsInCarriageID++;
        return objectsInCarriage[objectsInCarriageID];
    }
}
