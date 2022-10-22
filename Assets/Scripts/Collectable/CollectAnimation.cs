using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectAnimation : MonoBehaviour
{
    Transform mT;
    Vector3 initPose;
    Quaternion initRot;
    private void Awake()
    {
        mT = transform;
        initPose = mT.localPosition;
        initRot = mT.rotation;
        if (mT.rotation.x!=0)
        {
            mT.rotation = Quaternion.Euler(-90, 90, -90);
        }
        mT.localPosition += Vector3.up*35;
    }
    private void OnEnable()
    {
        mT.DOScale(mT.localScale * 4, 0.3f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            mT.DOLocalMoveY(initPose.y, 0.7f);
            mT.DOLocalRotateQuaternion(initRot, 0.7f);
        }) ;
    }
}
