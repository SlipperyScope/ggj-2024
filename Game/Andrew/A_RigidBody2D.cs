using Godot;
using System;

public partial class A_RigidBody2D : Godot.RigidBody2D
{
    public int heightAbove = 0;
    private Boolean isMoving = false;
    private Boolean reachedSpeed = false;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Freeze = true;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        heightAbove = (int)Math.Round(-3 * GlobalPosition.Y / 100); //screw precision. Game jam
        if (reachedSpeed)
        {
            if (LinearVelocity.X < 150)
            {
                PhysicsMaterialOverride.Bounce = 0.2f;
                LinearVelocity = new Vector2(0f, 0f);
                AngularVelocity = 0f;

            }
            else if (LinearVelocity.X < 200)
            {
                PhysicsMaterialOverride.Bounce = 0.4f;

            }
            else if (LinearVelocity.X < 400)
            {
                PhysicsMaterialOverride.Bounce = 0.6f;
            }
        }
        else if (LinearVelocity.X > 400)
        {
            reachedSpeed = true;
        }
    }
}
