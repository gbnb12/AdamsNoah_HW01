using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inheritance;

namespace indexer
{
    public class PlayerMissile : Projectile
    {
        protected override void Impact(Collision otherCollision)
        {
            otherCollision.rigidbody.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
