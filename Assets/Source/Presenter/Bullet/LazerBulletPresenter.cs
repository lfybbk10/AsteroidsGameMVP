using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBulletPresenter : BulletPresenter, IBullet
{
    public void Init(Transform shootPoint)
    {
        Destroy(gameObject, 1f);
        LazerBulletModel lazerBullet = new LazerBulletModel();
        transform.position = shootPoint.position;
        transform.rotation = shootPoint.rotation;
        transform.parent = shootPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"уничтножил {collision.name}");
    }
}
