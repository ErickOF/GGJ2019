using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour {
    private TextMeshProUGUI textExperience;
    private TextMeshProUGUI textLevel;
    private string EXP = "Experience: ";
    private string LEVEL = "Level: ";

    void Start() {
        textLevel = GameObject.FindWithTag("TextLevel").GetComponent<TextMeshProUGUI>();
        textExperience = GameObject.FindWithTag("TextExperience").GetComponent<TextMeshProUGUI>();
    }

    void Update() {
    	textExperience.text = EXP + Player.experience.ToString();
    	textLevel.text = LEVEL + Player.level.ToString();
    }
}
