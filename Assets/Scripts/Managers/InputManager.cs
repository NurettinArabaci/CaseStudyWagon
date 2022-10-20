using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] float inputSensitivityHorizontal;
    [SerializeField] float inputSensitivityVertical;


    [Header("Cross Platform")]
    [SerializeField] float iOS_Coefficient;



    private TrainController _trainMovement;

    private void Start()
    {
        _trainMovement = TrainController.Instance;
    }

    public void Update()
    {
        _trainMovement.inputAxis = GetAxis();
    }

    public Vector2 GetAxis()
    {
        Vector2 delta = Vector2.zero;


        if (Input.GetMouseButton(0))
        {
            delta.x = Input.GetAxis("Mouse X");
            delta.y = Input.GetAxis("Mouse Y");
            if (Input.touchCount > 0)
            {
                delta.x = Input.touches[0].deltaPosition.x;
                delta.y = Input.touches[0].deltaPosition.y;
                delta *= iOS_Coefficient;
                
            }
        }


        float horizontalAxis = delta.x * inputSensitivityHorizontal;
        float verticalAxis = delta.y * inputSensitivityVertical;

        return new Vector2(horizontalAxis, verticalAxis);
    }
}
