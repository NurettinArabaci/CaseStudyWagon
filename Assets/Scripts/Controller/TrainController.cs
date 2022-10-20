using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoSingleton<TrainController>
{
    Transform mT;

    [SerializeField] public float forwardSpeed;
    [SerializeField] public float sidewaysSpeed;

    [SerializeField] private float mapBorder;


    public Vector2 inputAxis; //set by input manager

    protected override void Awake()
    {
        base.Awake();
        mT = transform;
    }

    public void Update()
    {
        if (GameManager.Instance.gameState != GameState.Play) return;

        Movement();

    }

    public void FixedUpdate()
    {
        if (GameManager.Instance.gameState != GameState.Minigame) return;
        MiniGameMove();
    }

    void Movement()
    {
        var currentPosition = mT.position;

        var posX = sidewaysSpeed * inputAxis[0] * Time.deltaTime + currentPosition.x;

        posX = Mathf.Clamp(posX, -mapBorder, mapBorder);
        currentPosition.x = posX;

        //forward
        currentPosition.z += Time.deltaTime * forwardSpeed;

        mT.position = currentPosition;

        CollectableEvents.Fire_OnMovementLerp();
    }

    void MiniGameMove()
    {
        var currentPosition = mT.position;
        currentPosition.z += Time.fixedDeltaTime * forwardSpeed;

        mT.position = currentPosition;
    }
}
