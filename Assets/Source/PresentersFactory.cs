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

    public void CreateAsteroidPart(AsteroidPresenter asteroidPresenter)
    {
        if(asteroidPresenter is BigAsteroidPresenter)
        {
            for (int i = 0; i < _partsCount; i++)
            {
                MiddleAsteroidPresenter midAsteroid = CreatePresenter(_middleAsteroidTemplte) as MiddleAsteroidPresenter;
            }
        }
        else if(asteroidPresenter is MiddleAsteroidPresenter)
        {
            for (int i = 0; i < _partsCount; i++)
            {
                SmallAsteroidPresenter midAsteroid = CreatePresenter(_smallAsteroidTemplte) as SmallAsteroidPresenter;
            }
        }
    }

    public void CreateAsteroid()
    {
        BigAsteroidPresenter bigAsteroidPresenter = CreatePresenter(_bigAsteroidTemplte) as BigAsteroidPresenter;
    }

    private Presenter CreatePresenter(Presenter template)
    {
        Presenter presenter = Instantiate(template);
        
        return presenter;
    }
}
