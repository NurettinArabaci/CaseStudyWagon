using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainController : MonoSingleton<TrainController>
{
    Transform mT;

    [Header("FuelOil")]
    public float fuelOilAmount = 100f;
    [SerializeField] Slider fuelOilFillAmount;
    [SerializeField] GameObject fuelOilObj;

    [Header("Inputs")]
    [Space(10)]
    [SerializeField] public float forwardSpeed;
    [SerializeField] public float sidewaysSpeed;

    [SerializeField] private float mapBorder;
 
    public Vector2 inputAxis; //set by input manager

    [Header("VFX")]
    [Space(10)]
    [SerializeField] Transform smokeVfx;
    [SerializeField] Transform smokeVfxPose;



    private float initFuelOil;
    

    protected override void Awake()
    {
        base.Awake();
        mT = transform;
        initFuelOil = fuelOilAmount;
        
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

        smokeVfx.position = smokeVfxPose.position;

        CollectableEvents.Fire_OnMovementLerp();

        FuelOilReduce();
    }

    void FuelOilReduce()
    {
        fuelOilAmount -= Time.deltaTime * 7;

        fuelOilFillAmount.value = fuelOilAmount / initFuelOil;

        CheckDeath();
    }

    public void FuelOilIncrease()
    {
        fuelOilAmount += 30;
        if (fuelOilAmount > 100) fuelOilAmount = 100;
    }

    public void OnDamage(float _damage)
    {
        CameraShakeController.Instance.ShakeCam();
        fuelOilAmount -= _damage;
        
    }

    public void FuelActiveInactive(bool state)
    {
        fuelOilObj.SetActive(state);
    }

    void CheckDeath()
    {
        if (fuelOilAmount <= 0)
        {
            fuelOilAmount = 0;
            GameStateEvent.Fire_OnChangeGameState(GameState.Lose);
        }
            
    }

    void MiniGameMove()
    {
        var currentPosition = mT.position;
        currentPosition.z += Time.fixedDeltaTime * forwardSpeed;

        mT.position = currentPosition;
        smokeVfx.position = smokeVfxPose.position;
    }
}