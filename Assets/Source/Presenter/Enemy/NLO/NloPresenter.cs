using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NloPresenter : EnemyPresenter
{
    private NloModel _nloModel;

    public void Init(Transform player, Vector2 position)
    {
        transform.position = position;
        _nloModel = new NloModel(player, GetComponent<Rigidbody2D>());
    }

    private void FixedUpdate()
    {
        _nloModel.Update();
    }
}
