using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private PresentersFactory _factory;
    [SerializeField] private Camera _camera;

    private int _index;
    private float _secondsPerIndex = 1f;
    private float _radius;

    private void Start()
    {
        _radius = GetRadius();
    }

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
            Vector2 position = GetPositionOutSideCamera();
            Vector2 direction = GetDirectionTroughScreen(position);
            _factory.CreateAsteroid(position, direction);
        }
    }

    private Vector2 GetPositionOutSideCamera()
    {
        return Random.insideUnitCircle.normalized * _radius;

    }

    private float GetRadius()
    {
        Vector3 leftDown = _camera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 leftUp = _camera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        Vector3 rightUp = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float a = (leftUp - leftDown).y;
        float b = (rightUp - leftUp).x;
        float radius = 1f / 2f * Mathf.Sqrt(((a * a) + (b * b)));
        return radius;
    }

    private Vector2 GetDirectionTroughScreen(Vector2 position)
    {
        return (new Vector2(Random.value, Random.value) - position).normalized;
    }
}
