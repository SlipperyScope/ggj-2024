using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace ggj2024;

[GlobalClass]
public partial class SceneChanger : Node
{
	[Export(PropertyHint.File)]
	private string NextScene;

	[Export]
	private Button BindToButton;

	/// <summary>
	/// Immediately change the scene when the node is loaded
	/// </summary>
	[Export]
	protected Boolean ChangeOnReady { get; set; } = false;

	public override void _Ready()
	{
		if (ChangeOnReady is true)
		{
			/*var error = */CallDeferred(nameof(ChangeScene));
			//if (error is not Error.Ok)
			//{
			//    GD.PrintErr($"{error}: {NextScene}");
			//}

			//return;
		}

		if (BindToButton is not null)
		{
			BindToButton.Pressed += () => ChangeScene();
		}
	}

	public Error ChangeScene() => GetTree().ChangeSceneToFile(NextScene);
}
