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

    public void PickUpObject(Stickman stickman=null, Coal coal=null)
    {
        if (stickman!=null)
        {
            stickmanScore++;
        }

        if (coal!=null)
        {
            coalScore++;
        }
    }
}
