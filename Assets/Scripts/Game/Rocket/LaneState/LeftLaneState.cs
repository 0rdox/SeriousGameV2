using UnityEngine;

public class LeftLaneState : AbstractLaneState
{
    public LeftLaneState(RocketController rocketController) : base(rocketController)
    {
    }

    public override void MoveLeft()
    {
        // Intentionally left empty to prevent moving left when already in the leftmost lane.
    }

    public override void MoveRight()
    {
        MoveTowards(new Vector2(2, 0));
        rocketController.laneState = new CenterLaneState(rocketController);
    }
}
