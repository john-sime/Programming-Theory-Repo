using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy // Example of Inheritance
{
    public override void MoveOrStay(int turn) // Example of Polymorphism
    {
        if (turn % 3 != 0) // Moves on turns 1, 2, 4, 5, etc.
        {
            MakeMove();
        }
    }
}
