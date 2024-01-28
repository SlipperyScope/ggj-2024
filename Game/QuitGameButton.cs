using Godot;
using System;

[GlobalClass]
public partial class QuitGameButton : Button
{
    public override void _Ready()
    {
        Text = "Quit";
        ButtonDown += () => GetTree().Quit();
    }
}
