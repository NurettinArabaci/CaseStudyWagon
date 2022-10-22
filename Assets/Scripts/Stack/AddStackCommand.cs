using System;
using System.Collections.Generic;
using UnityEngine;

public class AddStackCommand
{
    private AddStackKeyParams _params;

    public AddStackCommand(AddStackKeyParams param)
    {
        _params = param;
    }

    public void OnAddOnStack(GameObject gO)
    {
        Transform mT = gO.transform;

        mT.SetParent(_params._transform);

        if (_params._collectables.Count < 1)
        {
            mT.position = _params._transform.position + 1.6f * Vector3.back;

            _params._collectables.Add(gO);

            return;
        }

        mT.position =_params._collectables[_params._collectables.Count - 1].transform.position + 1.6f * Vector3.back;

        _params._collectables.Add(gO);

        OnShakeStack();

        CameraController.Instance.CamGoBackOnStack();

    }

    public void OnShakeStack()
    {
        _params._monoBehaviour.StartCoroutine(_params._shakeStackCommand.HandleShakeOfStack());
    }
}
