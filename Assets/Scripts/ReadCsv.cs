using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReadCsv : MonoBehaviour
{
    // Hold a reference to the CSV
    [SerializeField]
    private TextAsset _partsCSV;
    // Hold an array of every object tag so that we can search for each one later
    private string[] _tags = {"Nut", "Bolt", "Ring", "Lid", "Glove Finger", "Glove Finger (No Ring)", "Piston", "Connector", "Hub", "Cog", "Washer", "Plate"};
    // Defines the character we use to separate between the fields in the CSV
    private char _fieldSeperator = ',';

    void Start()
    {
        // Split up each field in the CSV and assign it to the fields array, there's only 1 line so don't need to worry about splitting lines as well
        string[] fields = _partsCSV.text.Split(_fieldSeperator);

        foreach (string tag in _tags)
        {
            GameObject[] tagGameObjects = GameObject.FindGameObjectsWithTag(tag);


            foreach (GameObject obj in tagGameObjects)
            {
                //Debug.Log(obj.tag);
                TextMesh textMesh = obj.GetComponent<TextMesh>();

                foreach (string field in fields)
                {
                    Debug.Log(field);
                    if (field == obj.tag)
                    {
                        //Debug.Log("It's a match");
                        textMesh.text = field;
                    }

                    // else 
                    // {
                    //     return;
                    // }

                } 
                
            }
        }
    }
}
