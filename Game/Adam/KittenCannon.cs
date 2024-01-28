using Godot;
using System;

public partial class KittenCannon : Node2D
{
    [Export]
    public A_RigidBody2D shootie;

    private Sprite2D armSprite;
    private AudioStreamPlayer audioPlayer;

    private Boolean hasShot = false;

	public override void _Ready()
	{
        armSprite = GetNode<Sprite2D>("arm");
        audioPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
	}

	public override void _Process(double delta)
	{
        if (Input.IsActionPressed("UpBuddon") && armSprite.RotationDegrees > -60)
        {
            armSprite.RotationDegrees -= (float)(5 * delta);
            GD.Print(armSprite.RotationDegrees);
        }

        if (Input.IsActionPressed("DownBuddon") && armSprite.RotationDegrees < -8)
        {
            armSprite.RotationDegrees += (float)(5 * delta);
            GD.Print(armSprite.RotationDegrees);
        }

        if (Input.IsActionJustPressed("Space"))
        {
            if (!hasShot)
            {
                hasShot = true;
                ShootYourShot();
            }
            else if (shootie.stopped)
            {
                shootie.ResetPos();
                hasShot = false;
            }
        }
	}

    private void ShootYourShot()
    {
        audioPlayer.Play();
        shootie.Freeze = false;
        shootie.ApplyCentralImpulse(new Vector2(500, 0).Rotated(armSprite.Rotation) * 8f); //*5 for min, 10+ for max?
    }
}
