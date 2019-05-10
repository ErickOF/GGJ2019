using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour {
	// Keys
    public KeyCode FOWARD;
    public KeyCode BACK;
    public KeyCode OPTION;
    public KeyCode EXIT;

	private int pointerOption = 0;
	private int currentColor = 1;
	private int maxOption = 2;
	private float timer = Constants.TIME_COLOR_CHANGE;
	private Color[] colors = {new Color(1, 0.6f, 0, 1), Color.red};
    private TextMeshProUGUI[] menuOptions;

    void Start() {
    	menuOptions = new TextMeshProUGUI[3];
        menuOptions[0] = GameObject.FindWithTag("TextPlay").GetComponent<TextMeshProUGUI>();
        menuOptions[1] = GameObject.FindWithTag("TextInstructions").GetComponent<TextMeshProUGUI>();
        menuOptions[2] = GameObject.FindWithTag("TextExit").GetComponent<TextMeshProUGUI>();
    	menuOptions[pointerOption].color = colors[currentColor];
    }

    void Update() {
    	timer -= Time.deltaTime;
    	if (timer < 0) {
    		timer = Constants.TIME_COLOR_CHANGE;
    		currentColor = 1 - currentColor;
    		menuOptions[pointerOption].color = colors[currentColor];
    	}
    	// Change menu option
    	if (Input.GetKeyDown(FOWARD)) {
    		pointerOption--;
    		timer = Constants.TIME_COLOR_CHANGE;
    		currentColor = 1;
    		menuOptions[pointerOption].color = colors[currentColor];
        }
        if (Input.GetKeyDown(BACK)) {
            pointerOption++;
            timer = Constants.TIME_COLOR_CHANGE;
    		currentColor = 1;
    		menuOptions[pointerOption].color = colors[currentColor];
        }
        if (Input.GetKey(EXIT)) {
	        Application.Quit();
        }
        if (Input.GetKeyDown(OPTION)) {
        	switch (pointerOption) {
	        	case 0:
	        		SceneManager.LoadScene("Epilogue", LoadSceneMode.Single);
	        		break;
	        	case 1:
	        		SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
	        		break;
	        	case 2:
	        		Application.Quit();
	        		break;
	        	default:
	        		break;
	        }
        }
        // Cyclical option select
        if (pointerOption < 0) {
        	pointerOption = maxOption;
        } else if (pointerOption > maxOption) {
        	pointerOption = 0;
        }
        // Paint orange the other options
        switch (pointerOption) {
        	case 0:
        		menuOptions[1].color = colors[0];
        		menuOptions[2].color = colors[0];
        		break;
        	case 1:
        		menuOptions[0].color = colors[0];
        		menuOptions[2].color = colors[0];
        		break;
        	case 2:
        		menuOptions[0].color = colors[0];
        		menuOptions[1].color = colors[0];
        		break;
        	default:
        		break;
        }
    }
}
