using Godot;
using System;

public partial class Rainbow : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += onBodyEntered;
	}

	private void onBodyEntered(Node2D body)
	{
        ((A_RigidBody2D)body).ApplyCentralImpulse(new Vector2(500f, -100f) * 10f);
	}
}
