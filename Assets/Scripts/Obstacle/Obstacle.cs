using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IAttackable
{
    public void Attack(float damage)
    {
        TrainController.Instance.OnDamage(damage);
        EventManager.Fire_OnLowHpPanel();
        GetComponent<Collider>().enabled = false;
    }
}
