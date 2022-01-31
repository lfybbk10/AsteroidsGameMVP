using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGunModel : GunModel
{

    public LazerGunModel(Transform shootPoint, PresentersFactory factory)
    {
        Factory = factory;
        ShootPoint = shootPoint;
    }

    public void Shoot()
    {
        Factory.CreateBullet(ShootPoint, this);
    }
}
