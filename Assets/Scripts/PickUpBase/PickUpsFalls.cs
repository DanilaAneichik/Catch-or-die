﻿using UnityEngine;
using Random = UnityEngine.Random;

public class PickUpsFalls : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject[] _pickUpsArray;

    [SerializeField] private float _fallSpeed;

    [SerializeField] private float _minSpeed;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        InvokeRepeating("SpawnPickUps", 1, _fallSpeed);
    }

    private void Update()
    {
        Debug.Log($"Speed of obj: {_fallSpeed}");
    }

    #endregion


    #region Public methods

    public void ChangeSpeed(float speed)
    {
        if (_fallSpeed <= _minSpeed)
            _fallSpeed = _minSpeed;
        _fallSpeed += speed;
        //transform.position -= new Vector3(0, speed * Time.deltaTime, 0); пытался изменить скорость падения пикапов
    }

    #endregion


    #region Private methods

    private void SpawnPickUps()
    {
        int randomNumber = Random.Range(0, _pickUpsArray.Length);
        Instantiate(_pickUpsArray[randomNumber], new Vector3(Random.Range(-2.8f, 2.8f), 4, 0.1f), Quaternion.identity);
    }

    #endregion
}