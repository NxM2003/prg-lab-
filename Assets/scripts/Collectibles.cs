using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public string nameCollectable;
    public int score;
  

    public Collectibles(string name, int scorevalue)
    {
        this.nameCollectable = name;
        this.score = scorevalue;
     
    }

    public void UpdateScore()
    {
        SystemUI.scoremanager.UpdateScore(score);
    }
}
