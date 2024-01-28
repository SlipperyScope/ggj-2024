using Godot;
using System;

[GlobalClass]
public partial class QuitGameButton : Button
{
    public override void _Ready()
    {
        Text = "Quit";
        ButtonDown += () => CallDeferred(nameof(QuitGame));
    }

    private void QuitGame() => GetTree().Quit();
}
