﻿using UnityEngine;
using Random = UnityEngine.Random;

public class PickUpsFalls : MonoBehaviour
{
    #region Variables

    [SerializeField] private PickUpBase[] _pickUpsArray;

    [SerializeField] private float _fallSpeed;

    [SerializeField] private float _maxSpeed;

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
        _fallSpeed += speed;

        if (_fallSpeed >= _maxSpeed)
            _fallSpeed = _maxSpeed;
    }

    #endregion


    #region Private methods

    private void SpawnPickUps()
    {
        int randomNumber = Random.Range(0, _pickUpsArray.Length);
        PickUpBase pickUp = Instantiate(_pickUpsArray[randomNumber], new Vector3(Random.Range(-2.8f, 2.8f), 4, 0.1f),
            Quaternion.identity);
        pickUp.SetSpeed(_fallSpeed);
    }

    #endregion
}