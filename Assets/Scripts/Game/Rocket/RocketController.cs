using System;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public AbstractLaneState laneState;
    public ServiceLocator serviceLocator;
    private GameManager _gameManager;
    public float energyConsumption = 1.0f;
    public float collisionEnergyCost = 10f; 
    
    private float _timeInterval = 1f;
    private float _timeSpent;

    private void Start()
    {
        laneState = new CenterLaneState(this);
        _gameManager = serviceLocator.GetGameManager();
    }

    private void Update()
    {
        if (_timeInterval < _timeSpent)
        {
            _gameManager.SubtractEnergy(energyConsumption);

            _timeSpent = 0;
        }
        else
        {
            _timeSpent += 1.0f * Time.deltaTime;
        }
    }

    public void Move(Direction direction)
    {
        if (direction == Direction.Left) laneState.MoveLeft();
        if (direction == Direction.Right) laneState.MoveRight();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            
            _gameManager.SubtractEnergy(collisionEnergyCost);
        }
    }

    public enum Direction
    {
        Left,
        Right
    }
}
