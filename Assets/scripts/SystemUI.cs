using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SystemUI : MonoBehaviour
{
    public static SystemUI scoremanager;
    public TextMeshProUGUI scoreUI;
    int totalscore = 0;

    private void Awake()
    {
        if (scoremanager == null)
        {
            scoremanager = this;
        }

        scoreUI.text = "Score: 0";
    }

    public void UpdateScore(int score)
    {
        totalscore += score;
        Debug.Log(totalscore);
        scoreUI.text = "Score: " + totalscore.ToString();

    }
   
}
