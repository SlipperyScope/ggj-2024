using Godot;
using System;

public partial class Horner : Area2D
{
    private AudioStreamPlayer hornPlayer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        hornPlayer = GetNode<AudioStreamPlayer>("HornPlayer");
		BodyEntered += onBodyEntered;
	}

	private void onBodyEntered(Node2D body)
	{
        hornPlayer.Play();
	}
}
