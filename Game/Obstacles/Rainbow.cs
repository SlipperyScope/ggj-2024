using Godot;
using System;

public partial class Rainbow : Area2D
{
    private AudioStreamPlayer audioPlayer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        audioPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		BodyEntered += onBodyEntered;
	}

	private void onBodyEntered(Node2D body)
	{
        audioPlayer.Play();
        ((A_RigidBody2D)body).ApplyCentralImpulse(new Vector2(500f, -300f) * 10f);
	}
}
