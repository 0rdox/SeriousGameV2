using UnityEngine;

public class CenterLaneState : AbstractLaneState
{
    public CenterLaneState(RocketController rocketController) : base(rocketController)
    {
    }

    public override void MoveLeft()
    {
        MoveTowards(new Vector2(-2, 0));
        rocketController.laneState = new LeftLaneState(rocketController);
    }

    public override void MoveRight()
    {
        MoveTowards(new Vector2(2, 0));
        rocketController.laneState = new RightLaneState(rocketController);
    }
}
