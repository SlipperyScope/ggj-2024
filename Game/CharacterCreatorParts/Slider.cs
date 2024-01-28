using Godot;
using System;

[Tool]
public partial class Slider : MarginContainer
{
    // The text that gets shown in the UI
    [Export]
    public string Label;

    // The property on the character config to modify when this slider
    // is manipulated (gaaaaaaaaammmee jam!)
    [Export]
    public string ConfigKey;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        var label = GetNode<RichTextLabel>("Split/Label");
        var slider = GetNode<HSlider>("Split/SliderUI");
        label.Text = Label;

        slider.ValueChanged += (double val) => {
            GD.Print($"{Label} changed: {val}");
        };
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (Engine.IsEditorHint()) {
            GetNode<RichTextLabel>("Split/Label").Text = Label is null || Label == "" ? "<No Label>" : Label;
        }
	}
}
