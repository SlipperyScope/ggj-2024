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
        // Call ChangeScene on the scene manager (who would have thought), make sure to set the res path

        //if (this.HasChildOfType(out SceneChanger sceneChanger))
        //{
        //    sceneChanger.ChangeScene();
        //}
    }
}
