using Godot;
using System;

public partial class RigidBody2D : Godot.RigidBody2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ApplyCentralImpulse(new Vector2(500f, -100f) * 10f);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public override void _PhysicsProcess(Double delta)
    {

    }

    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
        base._IntegrateForces(state);
    }
}
