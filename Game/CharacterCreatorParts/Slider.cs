using Godot;
using System;

// Custom delegate instead of an event to match the Range.ValueChanged event
public delegate void ValueChangedEventHandler(float value);

[Tool]
public partial class Slider : MarginContainer
{
    // The text that gets shown in the UI
    [Export]
    public string Label;
    public HSlider slider;

    public ValueChangedEventHandler ValueChanged;
    public float Value {
        get {
            return (float)this.slider.Value;
        }
    }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        var label = GetNode<RichTextLabel>("Split/Label");
        slider = GetNode<HSlider>("Split/SliderUI");
        label.Text = Label;

        slider.ValueChanged += (double val) => {
            ValueChanged?.Invoke((float)val);
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
