using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btLauncherController : MonoBehaviour {

    GameObject mPowerSlider;// 'sldPower' component reference.
    GameObject mLaunchButton;

	// Use this for initialization
	void Start () {
        this.mPowerSlider = GameObject.Find("sldPower");
        this.mLaunchButton = GameObject.Find("btLauncher");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setActive(bool active)
    {
        mPowerSlider.SetActive(active);
        mLaunchButton.SetActive(active);
    }

    public void Launch()
    {
        Main.Launch(mPowerSlider.GetComponent<Slider>().value);
    }
}
