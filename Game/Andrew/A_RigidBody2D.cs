using Godot;
using System;

public partial class A_RigidBody2D : Godot.RigidBody2D
{
    public int heightAbove = 0;
    public Boolean stopped = false;
    private Boolean reachedSpeed = false;
    private Vector2 startPoint;
    private float startFriction;
    private float startBounce;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Freeze = true;
        startPoint = GlobalPosition;
        startFriction = PhysicsMaterialOverride.Friction;
        startBounce = PhysicsMaterialOverride.Bounce;
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
                PhysicsMaterialOverride.Friction = 1f;
                AngularVelocity = 0f;
                stopped = true;
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

    public void ResetPos()
    {
        GlobalPosition = startPoint;
        PhysicsMaterialOverride.Friction = startFriction;
        PhysicsMaterialOverride.Bounce = startBounce;
        stopped = false;
        reachedSpeed = false;
    } 
}
