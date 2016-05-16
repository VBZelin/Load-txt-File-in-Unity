using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadtxtFile : MonoBehaviour
{
    // Reference of text
    TextAsset textAsset;
    Text dialogText;

    // String
    string[] myLines;

    // Reference of line number
    int lineNumber;

    Button nextLine, lastLine;

    // Use this for initialization
    void Start()
    {
        // load text
        textAsset = Resources.Load<TextAsset>("Game Dialog");

        // get component
        dialogText = GameObject.Find("dialog_text").GetComponent<Text>();
        nextLine = GameObject.Find("next_line").GetComponent<Button>();
        lastLine = GameObject.Find("last_line").GetComponent<Button>();

        nextLine.onClick.AddListener(Next);
        lastLine.onClick.AddListener(Last);

        if (textAsset)
        {
            myLines = (textAsset.text.Split("\n"[0]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lineNumber < 0)
        {
            lineNumber = 0;
        }
        else if (lineNumber > myLines.Length - 1)
        {
            lineNumber = myLines.Length - 1;
        }

        dialogText.text = myLines[lineNumber];
    }

    void Next()
    {
        lineNumber += 1;
    }

    void Last()
    {
        lineNumber -= 1;
    }
}
