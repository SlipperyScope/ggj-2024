using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ggj2024.CharacterParts.Physicalation.Heads;
using Godot;

namespace ggj2024.CharacterParts.Physicalation;

public partial class Puppet : Node2D
{

    private PuppetHead Head;

    [Export]
    private Godot.Range EyeHeight { get; set; }

    [Export]
    private Godot.Range EyeRotation { get; set; }

    [Export]
    private OptionButton HeadSelection { get; set; }
    [Export]
    private PackedScene[] Heads { get; set; }

    public override void _Ready()
    {
        Head = GetNode<PuppetHead>("Head") ?? throw new Exception("Node 'Head' not found");

        if (EyeHeight is not null)
            EyeHeight.ValueChanged += (v) => Head.EyeOffset = (Single)v;
        if (EyeRotation is not null)
            EyeRotation.ValueChanged += (v) => Head.EyeRotation = (Single)v;
        if (HeadSelection is not null)
            HeadSelection.ItemSelected += HeadSelection_ItemSelected;
    }

    private void HeadSelection_ItemSelected(Int64 value)
    {
        var index = (Int32)value;

        if (Heads.ElementAtOrDefault(index)?.Instantiate() is PuppetHead head)
        {
            RemoveChild(Head);
            AddChild(head);
            Head = head;
            head.EyeOffset = (Single)EyeHeight.Value;
            head.EyeRotation = (Single)EyeRotation.Value;
        }
        else
        {
            GD.Print($"Invalid puppet head scene at element {index}");
        }
    }
}
