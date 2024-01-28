using Godot;
using System;

public partial class Tramp : Area2D
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
        ((A_RigidBody2D)body).ApplyCentralImpulse(new Vector2(0f, -350f) * 10f);
	}
}
