/*-----------------*/
/*Basic Core Script*/
/*-----------------*/
//using UnityEngine;

//public class NewBehaviourScript : MonoBehaviour
//{

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.touchCount == 1)
//        {
//            Touch screenTouch = Input.GetTouch(0);

//            if (screenTouch.phase == TouchPhase.Moved)
//            {
//                transform.Rotate(0f, screenTouch.deltaPosition.x, 0f);
//            }
//        }
//    }
//}


/*------------------------------------------------*/
/*Script with Rotation speed and smoothness factor*/
/*------------------------------------------------*/
using UnityEngine;

public class dragCube : MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    public float smoothFactor = 0.1f; // Adjust this for smoother or faster rotation

    private Vector2 lastTouchPosition;
    private float currentRotationAmount = 0.0f;

    // Update is called once per frame
    void Update()
    {
        //currentRotationAmount = 0.0f;


        HandleTouchInput();
        ApplySmoothRotation();

        
    }

    void HandleTouchInput()
    {
        if (Input.touchCount == 1)
        {
            Touch screenTouch = Input.GetTouch(0);

            switch (screenTouch.phase)
            {
                case TouchPhase.Began:
                    lastTouchPosition = screenTouch.position;
                    break;

                case TouchPhase.Moved:
                    Vector2 touchDelta = screenTouch.position - lastTouchPosition;
                    float rotationDelta = touchDelta.x * rotationSpeed;

                    currentRotationAmount += rotationDelta;

                    lastTouchPosition = screenTouch.position;
                    break;
            }
        }
    }

    void ApplySmoothRotation()
    {
        // Smoothly interpolate the rotation
        float smoothedRotationAmount = Mathf.Lerp(0.0f, currentRotationAmount, smoothFactor);
        transform.Rotate(Vector3.up * smoothedRotationAmount * Time.deltaTime);

        // Gradually decrease the current rotation amount
        currentRotationAmount = Mathf.Lerp(currentRotationAmount, 0.0f, smoothFactor * Time.deltaTime);
    }
}