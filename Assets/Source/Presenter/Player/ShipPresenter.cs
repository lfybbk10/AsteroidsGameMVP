using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPresenter : Presenter
{
    private ShipModel _model;

    public void Init(ShipModel ship)
    {
        _model = ship;
    }

    private void Update()
    {
        if (_model is IUpdatable)
            _model.Update(Time.deltaTime);
    }
}
