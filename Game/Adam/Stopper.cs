using Godot;
using System;

public partial class Stopper : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += onBodyEntered;
	}

	private void onBodyEntered(Node2D body)
	{
        ((RigidBody2D)body).LinearVelocity = new Vector2(0f, 0f);
        ((RigidBody2D)body).PhysicsMaterialOverride.Bounce = 0.1f;
        ((RigidBody2D)body).PhysicsMaterialOverride.Friction = 0.99f;
	}
}
