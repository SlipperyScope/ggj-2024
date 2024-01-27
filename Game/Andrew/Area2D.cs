using Godot;
using System;

public partial class Area2D : Godot.Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += onBodyEntered;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void onBodyEntered(Node2D body)
	{
		
		GD.Print($"{body} entered me!");
	}
}
