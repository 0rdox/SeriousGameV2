using UnityEngine;

public class RightLaneState : AbstractLaneState
{
    public RightLaneState(RocketController rocketController) : base(rocketController)
    {
    }

    public override void MoveLeft()
    {
        MoveTowards(new Vector2(-2, 0));
        rocketController.laneState = new CenterLaneState(rocketController);
    }

    public override void MoveRight()
    {
        // Intentionally left empty to prevent moving right when already in the rightmost lane.
    }
}
