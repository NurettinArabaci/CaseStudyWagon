using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    public int coalScore;
    public int stickmanScore;

    protected override void Awake()
    {
        base.Awake();
    }

    public void PickUpObject(CollectedType collectedType)
    {
        if (collectedType==CollectedType.Stickman)
        {
            stickmanScore++;
        }

        else if (collectedType == CollectedType.Coal)
        {
            coalScore++;
        }
    }
}
