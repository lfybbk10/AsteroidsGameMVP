using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentersFactory : MonoBehaviour
{
    [SerializeField] private Presenter _defoultGunBulletTemplate;
    [SerializeField] private Presenter _lazerBulletTemplate;

    public void CreateBullet(Transform shootPoint, GunModel gun)
    {
        Debug.Log(gun is DefoultGunModel);
        if(gun is DefoultGunModel)
        {
            DefoultBulletPresenter bulletPresenter = (DefoultBulletPresenter)CreatePresenter(_defoultGunBulletTemplate);
            bulletPresenter.Init(shootPoint);
        }
        else if(gun is LazerGunModel)
        {
            LazerBulletPresenter lazerBulletPresenter = (LazerBulletPresenter)CreatePresenter(_lazerBulletTemplate);
            lazerBulletPresenter.Init(shootPoint);
        }

    }

    private Presenter CreatePresenter(Presenter template)
    {
        Presenter presenter = Instantiate(template);
        
        return presenter;
    }
}
