using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentersFactory : MonoBehaviour
{
    [SerializeField] private Presenter _defoultGunBulletTemplate;
    [SerializeField] private Presenter _lazerBulletTemplate;

    [SerializeField] private AsteroidPresenter _bigAsteroidTemplte;
    [SerializeField] private AsteroidPresenter _middleAsteroidTemplte;
    [SerializeField] private AsteroidPresenter _smallAsteroidTemplte;

    private int _partsCount = 2;

    public void CreateBullet(Transform shootPoint, GunModel gun)
    {
        Debug.Log(gun is DefoultGunModel);
        if(gun is DefoultGunModel)
        {
            DefoultBulletPresenter bulletPresenter = CreatePresenter(_defoultGunBulletTemplate) as DefoultBulletPresenter;
            bulletPresenter.Init(shootPoint);
        }
        else if(gun is LazerGunModel)
        {
            LazerBulletPresenter lazerBulletPresenter = CreatePresenter(_lazerBulletTemplate) as LazerBulletPresenter;
            lazerBulletPresenter.Init(shootPoint);
        }

    }

    public void CreateAsteroidPart(AsteroidPresenter asteroidPresenter, Vector2 position, Vector2 direction)
    {
        if(asteroidPresenter is BigAsteroidPresenter)
        {
            for (int i = 0; i < _partsCount; i++)
            {
                MiddleAsteroidPresenter midAsteroid = CreatePresenter(_middleAsteroidTemplte) as MiddleAsteroidPresenter;
                float randomOffset = Random.Range(-.5f, .5f);
                Vector2 newPosition = new Vector2(position.x + randomOffset, position.y + randomOffset);
                midAsteroid.Init(this, newPosition, direction);

            }
        }
        else if(asteroidPresenter is MiddleAsteroidPresenter)
        {
            for (int i = 0; i < _partsCount; i++)
            {
                SmallAsteroidPresenter smallAsteroid = CreatePresenter(_smallAsteroidTemplte) as SmallAsteroidPresenter;
                float randomOffset = Random.Range(-.5f, .5f);
                Vector2 newPosition = new Vector2(position.x + randomOffset, position.y + randomOffset);
                smallAsteroid.Init(this, newPosition, direction);
            }
        }
    }

    public void CreateAsteroid(Vector2 position, Vector2 direction)
    {
        BigAsteroidPresenter bigAsteroidPresenter = CreatePresenter(_bigAsteroidTemplte) as BigAsteroidPresenter;
        bigAsteroidPresenter.Init(this, position, direction);
    }

    private Presenter CreatePresenter(Presenter template)
    {
        Presenter presenter = Instantiate(template);
        
        return presenter;
    }
}
