using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
  
    public Vector3 playerPosition;

    
    public GameData()
    {
          // this is player last position where i saved 
        this.playerPosition = new Vector3(-18.4749f, 1.80f, 26.378f);
    }

}       