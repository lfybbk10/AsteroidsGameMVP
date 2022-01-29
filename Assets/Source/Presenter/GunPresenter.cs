using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPresenter : Presenter
{
    [SerializeField] private Transform _shootpoint;
    [SerializeField] private PresentersFactory _factory;


    private DefoultGunModel _defoultGunModel;
    private LazerGunModel _lazerGunModel;
    private LazerGunRollback _lazerGunRollback;

    private InputRouter _inputRouter;

    public void Init(InputRouter input)
    {
        _defoultGunModel = new DefoultGunModel(_shootpoint, _factory);
        _lazerGunModel = new LazerGunModel(_shootpoint, _factory);
        _lazerGunRollback = new LazerGunRollback();

        _inputRouter = input;

        _inputRouter.OnDefoultGunShoot += DefoultShoot;
        _inputRouter.OnLazertGunShoot += LazerShoot;
    }
    private void OnDisable()
    {
        _inputRouter.OnDefoultGunShoot -= DefoultShoot;
        _inputRouter.OnLazertGunShoot -= LazerShoot;
    }

    private void Update()
    {
        _lazerGunRollback.Update(Time.deltaTime);
    }

    private void DefoultShoot()
    {
        _defoultGunModel.Shoot();
    }

    private void LazerShoot()
    {
        if (_lazerGunRollback.CanShoot == false)
            return;

        _lazerGunModel.Shoot();
        _lazerGunRollback.SetShoted();
    }

}
