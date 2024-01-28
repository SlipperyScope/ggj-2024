using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ggj2024;

public partial class Main : Node
{
	public override void _Ready()
	{
		/*
		Call ChangeScene on the scene manager (who would have thought), make sure to set the res path
		
		To find it anywhere use

		//if (this.HasChildOfType(out SceneChanger sceneChanger))
		//{
		//    sceneChanger.ChangeScene();
		//}

		Or you can find it by name if you know it(the name in the inspector, which will be "SceneChanger" by default)

		// const String sceneChangerName = "SceneChanger";
		// GetNode<SceneChanger>(sceneChangerName)?.ChangeScene();
		
		You can also r-c it in the inspector and click "Access as Unique Name" and it you can access it with that name via 
		"%NameOfNode" no matter where it is in the scene heirarchy


		This has been Just the Tips, by Tilde. Toodles~
		*/
	}
}
