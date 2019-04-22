using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class questScript : MonoBehaviour 
{

    //make seperate excel file

    public InputField x1, y1, z1, x2, y2, z2;
    public TextAsset questData;
	
	void Start ()
    {
        string pattern = "(?<x1>-*\\d+),(?<y1>-*\\d+),(?<z1>-*\\d+),,(?<x2>-*\\d+),(?<y2>-*\\d+),(?<z2>-*\\d+),,-*\\d+,-*\\d+,-*\\d+,,-*\\d+,-*\\d+,-*\\d+,,-*\\d+,-*\\d+,,,";
        MatchCollection a = Regex.Matches(questData.text, pattern);
        /*foreach(Match match in a)
        {
            Debug.Log(match.Groups["x1"].ToString() + " " + match.Groups["y1"].ToString() + " " + match.Groups["z1"].ToString());
        }*/
        x1.text = a[0].Groups["x1"].ToString();
        y1.text = a[0].Groups["y1"].ToString();
        z1.text = a[0].Groups["z1"].ToString();

        x2.text = a[0].Groups["x2"].ToString();
        y2.text = a[0].Groups["y2"].ToString();
        z2.text = a[0].Groups["z2"].ToString();

        //string[] data = questData.text.Split(new char[] { '\n' });   ///array for entire data

        //Debug.Log(data.Length);

        /*for(int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });  //array for commas for each line. save that data somewhere.
            Quest q = new Quest();
            
        }*/
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}

/* string input = " ";
 if (Regex.IsMatch(
     */