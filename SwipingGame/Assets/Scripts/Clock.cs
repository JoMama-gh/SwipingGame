using UnityEngine;
using TMPro;
using System;

public class Clock : MonoBehaviour {
    public TextMeshProUGUI clockText;
    private float elapsedTime = 0f;


    // Update is called once per frame
    void Update() {
        elapsedTime += Time.deltaTime;
        int seconds = Mathf.FloorToInt(elapsedTime);
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;

        clockText.text = string.Format(
            "{0:00}:{1:00}",
            minutes,
            remainingSeconds);


    }
}
