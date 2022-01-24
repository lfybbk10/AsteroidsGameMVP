using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private ShipPresenter _ship;
    [SerializeField] private GunPresenter _gun;

    private InputRouter _input;

    private void Awake()
    {
        ShipModel ship = new ShipModel(_ship.GetComponent<Rigidbody2D>());
        _input = new InputRouter(ship);
        _ship.Init(ship);
        _gun.Init(_input);
    }

    private void OnEnable()
    {
        _input.OnEnable();
    }

    private void OnDisable()
    {
        _input.OnDisable();
    }

    private void Update()
    {
        _input.Update(Time.deltaTime);
    }
}
