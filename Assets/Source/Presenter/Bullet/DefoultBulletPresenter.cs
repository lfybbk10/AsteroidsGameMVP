using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefoultBulletPresenter : BulletPresenter, IBullet
{
    private DefoultBulletModel _bulletModel;

    public void Init(Transform shootPoint)
    {
        //TODO: OBJECT PULL OF BULLETS 
        Destroy(gameObject, 2f);
        _bulletModel = new DefoultBulletModel(GetComponent<Rigidbody2D>(), shootPoint.up);
        transform.position = shootPoint.position;
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyPresenter enemy))
            Destroy(gameObject);
    }
}
