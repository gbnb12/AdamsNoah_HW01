using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : CollectibleBase
{

    

    

    protected override void Collect(Player player)
    {

        player.Score();

    }

    
}
