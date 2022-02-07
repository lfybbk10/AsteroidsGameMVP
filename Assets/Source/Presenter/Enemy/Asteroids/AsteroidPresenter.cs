using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPresenter : EnemyPresenter
{
    private AsteroidModel _asteroidModel;
    private PresentersFactory _factory;
    private Vector2 _direction;

    
    public void Init(PresentersFactory factory)
    {
        _factory = factory;
        _asteroidModel = new AsteroidModel(Vector2.up, GetComponent<Rigidbody2D>());
        Destroy(gameObject, 3f);
    }

    public void Init(PresentersFactory factory, Vector2 position, Vector2 direction)
    {
        _factory = factory;
        transform.position = position;
        _direction = direction;
        _asteroidModel = new AsteroidModel(direction, GetComponent<Rigidbody2D>());
        Destroy(gameObject, 3f);
    }

    protected void OnAsteroidDestroy(AsteroidPresenter asteroid)
    {
        _factory.CreateAsteroidPart(asteroid, transform.position, _direction);
    }
}
