using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : CollectibleBase
{

    public GameObject scoreText;
    public int theScore;

    protected override void Collect(Player player)
    {

        theScore += 1;
        

    }
}
