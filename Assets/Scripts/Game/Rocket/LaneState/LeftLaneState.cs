using UnityEngine;

public class LeftLaneState : AbstractLaneState
{
    public LeftLaneState(RocketController rocketController) : base(rocketController)
    {
    }

    public override void MoveLeft()
    {
    }

    public override void MoveRight()
    {
        MoveTowards(new Vector2(2, 0));
        rocketController.laneState = new CenterLaneState(rocketController);
    }
}
