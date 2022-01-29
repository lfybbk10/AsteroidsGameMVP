using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DefoultGunModel : GunModel
{

    public event UnityAction<DefoultBulletModel> OnShoot;

    public DefoultGunModel(Transform shootPoint, PresentersFactory factory)
    {
        Factory = factory;
        ShootPoint = shootPoint;
    }

    public void Shoot()
    {
        Factory.CreateBullet(ShootPoint, this);
    }

}
