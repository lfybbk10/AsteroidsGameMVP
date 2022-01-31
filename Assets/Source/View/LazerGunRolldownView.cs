using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LazerGunRolldownView : MonoBehaviour
{
    [SerializeField] private TMP_Text _rollbackText;
    [SerializeField] private GunPresenter _gunPresenter;

    private bool _isRollingback = false;

    private void OnEnable()
    {
        _gunPresenter.OnShoot += StartCount;
        _gunPresenter.OnStopRollingBack += StopCount;
    }

    private void OnDisable()
    {
        _gunPresenter.OnShoot -= StartCount;
        _gunPresenter.OnStopRollingBack -= StopCount;
    }

    private void Update()
    {
        if (_isRollingback == false)
            return;

        _rollbackText.text = _gunPresenter.GetRollBackTime().ToString("F1");
    }

    private void StartCount()
    {
        _isRollingback = true;
    }

    private void StopCount()
    {
        _isRollingback = false;
        _rollbackText.text = "Ready";
    }
}
