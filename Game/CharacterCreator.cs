using Godot;
using System;

public partial class CharacterCreator : Node2D
{
	HFlowContainer Tabs;
	ScrollContainer HeadPanel;
	ScrollContainer BodyPanel;
	ScrollContainer LegsPanel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Tabs = GetNode<HFlowContainer>("CanvasLayer/UI/Split/Margin/Tabs");

		HeadPanel = GetNode<ScrollContainer>("CanvasLayer/UI/Split/HeadPanel");
		BodyPanel = GetNode<ScrollContainer>("CanvasLayer/UI/Split/BodyPanel");
		LegsPanel = GetNode<ScrollContainer>("CanvasLayer/UI/Split/LegsPanel");
		var HeadBtn = Tabs.GetNode<TextureButton>("Head");
		var BodyBtn = Tabs.GetNode<TextureButton>("Body");
		var LegsBtn = Tabs.GetNode<TextureButton>("Legs");

		// Don't be fancy, just game jam
		HeadBtn.Pressed += () => {
			BodyBtn.ButtonPressed = false;
			LegsBtn.ButtonPressed = false;
			HeadPanel.Visible = true;
			BodyPanel.Visible = false;
			LegsPanel.Visible = false;
		};
		BodyBtn.Pressed += () => {
			HeadBtn.ButtonPressed = false;
			LegsBtn.ButtonPressed = false;
			HeadPanel.Visible = false;
			BodyPanel.Visible = true;
			LegsPanel.Visible = false;
		};
		LegsBtn.Pressed += () => {
			HeadBtn.ButtonPressed = false;
			BodyBtn.ButtonPressed = false;
			HeadPanel.Visible = false;
			BodyPanel.Visible = false;
			LegsPanel.Visible = true;
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
