using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DefoultGun : GunModel
{
    private DefoultBulletModel _bulletPrefab;

    public event UnityAction<DefoultBulletModel> OnShoot;

    public DefoultGun(Transform shootPoint, DefoultBulletModel bullet, PresentersFactory factory)
    {
        Factory = factory;
        ShootPoint = shootPoint;
        _bulletPrefab = bullet;
    }

    public void Shoot()
    {
        Factory.CreateBullet(ShootPoint);
    }

}
