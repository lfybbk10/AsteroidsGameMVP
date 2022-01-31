using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPresenter : EnemyPresenter
{
    private PresentersFactory _factory;
    private AsteroidModel _asteroidModel;

    public void Init(PresentersFactory factory)
    {
        _factory = factory;
        _asteroidModel = new AsteroidModel(Vector2.up, GetComponent<Rigidbody2D>());
    }
}
