using UnityEngine;

public abstract class AbstractLaneState
{
    protected readonly RocketController rocketController;
    
    protected AbstractLaneState(RocketController rocketController)
    {
        this.rocketController = rocketController;
    }
    
    public abstract void MoveLeft();
    public abstract void MoveRight();

    protected void MoveTowards(Vector3 offset)
    {
        var rocketPosition = rocketController.transform.position;
        rocketController.transform.position = Vector2.MoveTowards(
            rocketPosition, 
            rocketPosition + offset, 
            2
        );
    }
}
