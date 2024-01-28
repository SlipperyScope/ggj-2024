using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace ggj2024.CharacterParts.Physicalation;

/// <summary>
/// You like put a texture on like a Sprite2D or whatever but, "~~SuRpRiSe~~" it's a a RigidBody
/// </summary>
[Tool]
[GlobalClass, Icon("res://Assets/Art/character/bodies/robot/robot-body-ornament.png")]
public partial class PhysicsSprite2D : RigidBody2D
{
    public Sprite2D Sprite { get; private set; }
    private CollisionShape2D Collider;
    private PinJoint2D PinJoint;

    /// <summary>
    /// Purge *all* children and repopulate
    /// </summary>
    [Export]
    private Boolean PurgeChildrenAndReset
    {
        get => false;
        set
        {
            if (value is true)
            {
                foreach (var child in GetChildren())
                {
                    if (child.GetParent() == this)
                    {
                        // Stuff might still do stuff when they are removed but gamejam. I think it's fine
                        RemoveChild(child);
                    }
                }

                Sprite = null;
                Collider = null;
                PinJoint = null;
                CallDeferred(nameof(Populate));
            }
        }
    }

    [Export]
    public Texture2D Texture
    {
        get => Sprite?.Texture;
        set
        {
            if (Sprite is not null)
            {
                Sprite.Texture = value;
            }
        }
    }

    [Export]
    public Vector2 TextureScale
    {
        get => Sprite?.Scale ?? Vector2.One;
        set
        {
            if (Sprite is not null)
            {
                Sprite.Scale = value;
            }
        }
    }

    public override void _EnterTree()
    {
        Populate();
        //foreach (var child in GetChildren())
        //{
        //    GD.Print(child);
        //}
        //GD.Print("~~~~");
    }

    private void AttachChild(Node node, Boolean expose = false)
    {
        if (node?.GetParent() != this)
        {
            AddChild(node);
        }
        if (expose is true)
        {
            node.Owner = GetTree().EditedSceneRoot;
        }
    }

    private void Populate()
    {
        const String spriteName = nameof(Sprite2D);
        if ((Sprite ??= FindChild(spriteName) as Sprite2D) is null){
            Sprite = new()
            {
                Name = spriteName,
            };

            if (IsInsideTree() is true)
            {
                // Do not expose sprite
            }
        }

        const String pinJointName = nameof(PinJoint);
        if ((PinJoint ??= FindChild(pinJointName) as PinJoint2D) is null)
        {
            PinJoint = new()
            {
                Name = pinJointName,
            };

            if (IsInsideTree() is true)
            {
                AttachChild(PinJoint, true);
                PinJoint.NodeA = GetPath();
            }
        }

        const String colliderName = nameof(CollisionShape2D);
        if ((Collider ??= FindChild(colliderName) as CollisionShape2D) is null)
        {
            Collider = new()
            {
                Name = colliderName,
                Shape = new CircleShape2D()
            };

            if (IsInsideTree() is true)
            {
                AttachChild(Collider, true);
            }
        }
    }
}