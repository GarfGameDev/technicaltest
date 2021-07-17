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
    

    // Update is called once per frame
    void Update()
    {
        RotateModel();
        ScaleModel();
    }

    // Created separate function for readability
    void RotateModel() 
    {
        if (Input.GetMouseButton(0))
        {
            // Storing a reference to both axis of the mouse's current position as well as the speed to rotate it by
            // Doing this for better readability
            float mouseX = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _rotationSpeed *Time.deltaTime;
            transform.Rotate(mouseY, mouseX, 0, Space.World);
        }
    }

    void ScaleModel()
    {
        // Storing the value of the slider from the UI into _scaleValue
        _scaleValue = _scaleSlider.value;
        // I'm wanting the model to scale evenly so I've set the x,y,z values of this vector 3 to the same
        transform.localScale = new Vector3(_scaleValue, _scaleValue, _scaleValue);
    }
}
