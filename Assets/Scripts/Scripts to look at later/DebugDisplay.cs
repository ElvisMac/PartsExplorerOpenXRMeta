using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugDisplay : MonoBehaviour
{
    Dictionary<string, string> debugLogs = new Dictionary<string, string>();
    public TMP_Text display;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable() {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type) {
        string[] splitString = logString.Split(char.Parse(":"));
        string debugKey = splitString[0];
        string debugValue = splitString.Length > 1 ? splitString[1] : "";

        if (debugLogs.ContainsKey(debugKey)) {
            debugLogs[debugKey] = debugValue;
        } else {
            debugLogs.Add(debugKey, debugValue);
        }

        string displayText = "";
        foreach (KeyValuePair<string, string> log in debugLogs) {
            if (log.Value == "") {
                displayText += log.Key + "\n";
            } else {
                displayText += log.Key + ": " + log.Value + "\n";
            }
        }

        display.text = displayText;
    }
}
