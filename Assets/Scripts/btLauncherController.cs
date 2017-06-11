using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btLauncherController : MonoBehaviour {
    
    Slider cPowerSlider;    // 'sldPower' component reference.

	// Use this for initialization
	void Start () {
        this.cPowerSlider = GameObject.Find("sldPower").GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Launch()
    {
        Main.Launch(cPowerSlider.value);
    }
}
