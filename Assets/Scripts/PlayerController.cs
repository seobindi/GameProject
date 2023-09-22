using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] JudgmentManager theJudgmentManager;

    void Update()
    {
        KeyAssignment();
    }

    private void KeyAssignment()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) { theJudgmentManager.CheckTiming("Up"); }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { theJudgmentManager.CheckTiming("Down"); }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) { theJudgmentManager.CheckTiming("Left"); }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { theJudgmentManager.CheckTiming("Right"); }
    }
}


