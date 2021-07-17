using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReadCsv : MonoBehaviour
{
    // Holds a reference to the CSV
    [SerializeField]
    private TextAsset _partsCSV;
    // Creates an array holding every object tag so that we can search for each one later
    private string[] _tags = {"Nut", "Bolt", "Ring", "Lid", "Glove Finger", "Glove Finger (No Ring)", "Piston", "Connector", "Hub", "Cog", "Washer", "Plate"};
    // Defines the character we use to separate between the fields in the CSV
    private char _fieldSeperator = ',';

    void Start()
    {
        // Split up each field in the CSV and assign it to the fields array, there's only 1 line so don't need to worry about splitting lines as well
        string[] fields = _partsCSV.text.Split(_fieldSeperator);

        // Cycles through the array for _tags and finds every object matching a tag
        foreach (string tag in _tags)
        {
            GameObject[] tagGameObjects = GameObject.FindGameObjectsWithTag(tag);

            // Iterates through each object found with the tag specified earlier and gets a reference to the TextMesh component in each one
            foreach (GameObject obj in tagGameObjects)
            {     
                TextMesh textMesh = obj.GetComponent<TextMesh>();

                // Checks to see if any of the words pulled from the CSV matches the Game Object tag and assigns the text field
                // in the TextMesh component the word in the CSV if it matches
                foreach (string field in fields)
                {
                    if (field == obj.tag)
                    {
                        textMesh.text = field;
                    }

                } 
                
            }
        }
    }
}
