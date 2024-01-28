using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace ggj2024.CharacterParts.Physicalation.Heads;
public partial class PuppetHead : Node2D
{
    private Sprite2D LeftEye;
    private Sprite2D RightEye;

    #region Eye Height
    [Export]
    private Single MaxEyeHeightOffset = 20f;

    public Single EyeOffset
    {
        get => _EyeOffset;
        set
        {
            var offset = Mathf.Remap(value, 0f, 100f, -MaxEyeHeightOffset, MaxEyeHeightOffset);
            //GD.Print($"{value} remapped to {offset}");
            SetY(LeftEye, LeftEye.Position.Y + offset - _EyeOffset);
            SetY(RightEye, RightEye.Position.Y + offset - _EyeOffset);
            _EyeOffset = offset;
        }
    }
    private Single _EyeOffset = 0f;
    #endregion


    #region Eye Rotation
    public Single EyeRotation
    {
        get => _EyeRotation;
        set
        {
            var rads = Mathf.Remap(value, 0f, 100f, -Mathf.Pi, Mathf.Pi);
            SetRotation(LeftEye, rads);
            SetRotation(RightEye, -rads);
        }
    }
    private Single _EyeRotation = 0f; 
    #endregion

    public override void _Ready()
    {
        LeftEye = FindChild("LeftEye", true) as Sprite2D;
        RightEye = FindChild("RightEye", true) as Sprite2D;
    }

    private static void SetY(Node2D node, Single height) => node.Position = new(node.Position.X, height);
    private static void SetRotation(Node2D node, Single rotation) => node.Rotation = rotation;
}
