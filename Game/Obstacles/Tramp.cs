using Godot;
using System;

public partial class Tramp : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += onBodyEntered;
	}

	private void onBodyEntered(Node2D body)
	{
        GD.Print("hit tramp");
        ((RigidBody2D)body).ApplyCentralImpulse(new Vector2(0f, -350f) * 10f);
	}
}
