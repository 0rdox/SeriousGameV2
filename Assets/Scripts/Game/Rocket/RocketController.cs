using System;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public AbstractLaneState laneState;

    private void Start()
    {
        laneState = new CenterLaneState(this);
    }

    public void Move(Direction direction)
    {
        if (direction == Direction.Left) laneState.MoveLeft();
        if (direction == Direction.Right) laneState.MoveRight();
    }
    
    public enum Direction
    {
        Left,
        Right
    }
}
