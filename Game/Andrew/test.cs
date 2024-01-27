using Godot;
using System;

public partial class test : Sprite2D
{
    [Export]
    public Vector2 Speed { get; set; } = new(0f, 50f);

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Position = Position + Speed * (Single)delta;
    }
}
