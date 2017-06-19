using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txtScoreBoard : MonoBehaviour {

    private Text mText;

	// Use this for initialization
	void Start () {
        mText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void SetText(string text)
    {
        mText.text = text;
    }
}
