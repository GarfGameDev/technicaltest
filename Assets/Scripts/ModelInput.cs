using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelInput : MonoBehaviour
{
    // Set value for the speed to rate the model by, will add way for user to adjust value if I have time
    private float _rotationSpeed = 300.0f;
    [SerializeField]
    private Slider _scaleSlider;
    private float _scaleValue;

    private bool _canTap = true;

    [SerializeField]
    private Camera _camera;

    private int _interpolationFramesCount = 5;
    private int _elapsedFrames = 0;


    

    // Update is called once per frame
    void Update()
    {
        RotateModel();
        ScaleModel();

        if (_canTap == true) 
        {
            LerpPieces();
        }
    }

    // Created separate function for readability
    void RotateModel() 
    {
        if (Input.GetMouseButton(1))
        {
            // prevent user from tapping and expanding pieces while rotating the model
            _canTap = false;
            // Storing a reference to both axis of the mouse's current position as well as the speed to rotate it by
            // Doing this for better readability
            float mouseX = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _rotationSpeed *Time.deltaTime;
            transform.Rotate(mouseY, -mouseX, 0, Space.World);
        }
        else 
        {
            _canTap = true;
        }
    }

    void ScaleModel()
    {
        // Storing the value of the slider from the UI into _scaleValue
        _scaleValue = _scaleSlider.value;
        // I'm wanting the model to scale evenly so I've set the x,y,z values of this vector 3 to the same
        transform.localScale = new Vector3(_scaleValue, _scaleValue, _scaleValue);
    }

    private void LerpPieces()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            float interpolationRatio = (float)_elapsedFrames / _interpolationFramesCount; 
            RaycastHit hit;
            // Cast a ray from the camera view to the position of the mouse
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // Get a reference to the LerpInfo script in each piece
                LerpInfo lerp = hit.transform.GetComponent<LerpInfo>();                    
                hit.transform.localPosition = Vector3.Lerp(new Vector3(-lerp.distance, 0, 0), Vector3.forward, interpolationRatio);

            }
        }
    }
}
