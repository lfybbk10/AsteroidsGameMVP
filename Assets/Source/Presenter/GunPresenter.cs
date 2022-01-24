using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPresenter : Presenter
{
    [SerializeField] private Transform _shootpoint;
    [SerializeField] private DefoultBulletModel _bulletPrefab;
    [SerializeField] private PresentersFactory _factory;

    private DefoultGun _defoultGunModel;
    private InputRouter _inputRouter;

    public void Init(InputRouter input)
    {
        _defoultGunModel = new DefoultGun(_shootpoint, _bulletPrefab, _factory);
        _inputRouter = input;
        _inputRouter.OnDefoultGunShoot += DefoultShoot;
    }

    private void DefoultShoot()
    {
        _defoultGunModel.Shoot();
    }

}
