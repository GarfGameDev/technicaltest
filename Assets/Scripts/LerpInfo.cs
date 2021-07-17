using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpInfo : MonoBehaviour
{
    // Specify the distance each piece will move so that we can see them all separated
    public float xDistance;
    public float yDistance;

    private bool _hasMoved = false;

    // return type function that returns the current value of _hasMoved which will either be true or false
    public bool MoveStatus()
    {
        return _hasMoved;
    }

    // Sets _hasMove to the opposite of its current value
    public void SetMoveStatus()
    {
        _hasMoved = ! _hasMoved;
    }
}
