using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefoultBulletPresenter : Presenter
{
    private DefoultBulletModel _bulletModel;

    public void Init(Transform shootPoint)
    {
        //TODO: OBJECT PULL OF BULLETS 
        Destroy(gameObject, 2f);
        _bulletModel = new DefoultBulletModel(GetComponent<Rigidbody2D>(), shootPoint.up);
        transform.position = shootPoint.position;
    }
}
