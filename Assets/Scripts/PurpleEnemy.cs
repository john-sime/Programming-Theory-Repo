using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemy : Enemy
{
    public override void MoveOrStay(int turn)
    {
        if (turn % 3 == 0) // Moves twice on turns 3, 6, 9, etc.
        {
            MakeMove();
            MakeMove();
        }
    }
}
