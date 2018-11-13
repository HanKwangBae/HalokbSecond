using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppStateManager : MonoBehaviour {

    private void Start()
    {
        Screen.SetResolution(Screen.width / 3, Screen.height / 3, false);
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
