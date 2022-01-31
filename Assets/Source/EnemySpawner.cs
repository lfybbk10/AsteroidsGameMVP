using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private PresentersFactory _factory;

    private int _index;
    private float _secondsPerIndex = 1f;

    private void FixedUpdate()
    {
        int newIndex = (int)(Time.time / _secondsPerIndex);

        if (newIndex > _index)
        {
            _index = newIndex;
            Tick();
        }
    }

    private void Tick()
    {
        float chance = Random.Range(0f, 100f);
        if(chance < 20)
        {
            Debug.Log("nlo");
        }
        else
        {
            _factory.CreateAsteroid();
        }
    }
}
