using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inheritance;

namespace indexer
{
    public class BossMissile : Projectile
    {
        protected override void Impact(Collision otherCollision)
        {
            gameObject.SetActive(false);
        }
    }
}