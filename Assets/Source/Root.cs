using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private ShipPresenter _ship;
    [SerializeField] private GunPresenter _gun;
    [SerializeField] private PlayerScorePresenter _scorePresenter;
    [SerializeField] private ScoreView _scoreView;

    private InputRouter _input;

    public ShipPresenter ShipPresenter => _ship;
    public PlayerScorePresenter ScorePresenter => _scorePresenter;

    private void Awake()
    {
        ShipModel ship = new ShipModel(_ship.GetComponent<Rigidbody2D>());
        _input = new InputRouter(ship);
        
        _ship.Init(ship);
        _gun.Init(_input);
        _scorePresenter.Init(_scoreView);
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
