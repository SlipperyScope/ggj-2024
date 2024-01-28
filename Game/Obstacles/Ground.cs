using Godot;
using System;

public partial class Ground : StaticBody2D
{

    [Export]
    public A_RigidBody2D shootie;
    private Label heightLabel;
    private Label distanceLabel;
    private Label restartLabel;
    private Area2D area;
    private AudioStreamPlayer audioPlayer;

    private Boolean hidingDistance = true;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        heightLabel = GetNode<Label>("Label");
        distanceLabel = GetNode<Label>("DistanceLabel");
        restartLabel = GetNode<Label>("RestartLabel");
        area = GetNode<Area2D>("Area2D");
        audioPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
        area.BodyEntered += onBodyEntered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        Position = new Vector2(shootie.Position.X, Position.Y);
        if (shootie.heightAbove > 0)
        {
            heightLabel.Text = shootie.heightAbove + " ft";
            heightLabel.Show();
        }
        else if (heightLabel.Visible)
        {
            heightLabel.Hide();
        } 

        if (shootie.stopped && hidingDistance)
        {
            distanceLabel.Text = (int)Math.Round(3 * shootie.GlobalPosition.X / 100) + " ft";
            distanceLabel.Show();
            restartLabel.Show();
            hidingDistance = false;
        }

        if (!hidingDistance && Input.IsActionJustPressed("Space"))
        {
            distanceLabel.Hide();
            restartLabel.Hide();
            hidingDistance = true;
        }

	}

    private void onBodyEntered(Node2D body)
    {
        audioPlayer.Play();
    }
}
