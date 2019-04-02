using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;

public class LoadFile : MonoBehaviour {

	// Use this for initialization
	void Start () {

		FileBrowser.SetFilters(false,new FileBrowser.Filter("CSV", ".csv"));
		//FileBrowser.SetDefaultFilter(".csv");

		FileBrowser.ShowLoadDialog((path) => { Debug.Log( "Selected: " + path ); }, () => { Debug.Log( "Canceled" ); },false,null,"Load CSV");
	}

}
