using Godot;
using System;

public partial class Stopper : Area2D
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
        audioPlayer.Stop();
        ((A_RigidBody2D)body).LinearVelocity = new Vector2(0f, 0f);
        ((A_RigidBody2D)body).AngularVelocity = 0f;
        ((A_RigidBody2D)body).PhysicsMaterialOverride.Bounce = 0.1f;
	}
}
