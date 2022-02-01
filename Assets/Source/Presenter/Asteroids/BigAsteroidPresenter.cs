using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroidPresenter : AsteroidPresenter
{
    protected override void Die()
    {
        OnAsteroidDestroy(this);
        base.Die();
    }
}
