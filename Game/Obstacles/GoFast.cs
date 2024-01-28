using Godot;
using System;

public partial class GoFast : Area2D
{
    private AudioStreamPlayer skrrtPlayer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        skrrtPlayer = GetNode<AudioStreamPlayer>("SkrrtPlayer");
		BodyEntered += onBodyEntered;
	}

	private void onBodyEntered(Node2D body)
	{
        skrrtPlayer.Play();
        ((A_RigidBody2D)body).ApplyCentralImpulse(new Vector2(500f, 0f) * 10f);
	}
}
