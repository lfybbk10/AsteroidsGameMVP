using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentersFactory : MonoBehaviour
{
    [SerializeField] private Presenter _defoultGunBulletTemplate;

    public void CreateBullet(Transform shootPoint)
    {
        DefoultBulletPresenter bulletPresenter = (DefoultBulletPresenter)CreatePresenter(_defoultGunBulletTemplate);
        bulletPresenter.Init(shootPoint);
    }

    private Presenter CreatePresenter(Presenter template)
    {
        Presenter presenter = Instantiate(template);
        
        return presenter;
    }
}
