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

    //
    // Eyes
    //
    [ExportGroup("Head Props")]
    [Export]
    private Slider EyeLeftSize;
    [Export]
    private Slider EyeRightSize;
    [Export]
    private Slider EyeLeftRotation;
    [Export]
    private Slider EyeRightRotation;
    [Export]
    private Slider EyeGap;
    [Export]
    private Slider EyeDrift;

    //
    // Mouth
    //

    [Export]
    private Slider MouthPosition;
    [Export]
    private Slider MouthWidth;
    [Export]
    private Slider MouthHeight;
    [Export]
    private Slider MouthRotation;

    //
    // Mouth
    //

    [Export]
    private Slider ChinStretch;
    [Export]
    private Slider ChinWidth;
    [Export]
    private Slider ChinElasticity;
    
    //
    // Base
    //

    [Export]
    private Slider HeadBaseWidth;
    [Export]
    private Slider HeadBaseHeight;
    
    //
    // Ornament
    //

    [Export]
    private Slider HeadOrnamentDynamic;

    //
    // Body
    //

    [ExportGroup("Body Props")]
    [Export]
    private Slider LeftArmLength;
    [Export]
    private Slider RightArmLength;
    [Export]
    private Slider ArmElasticity;
    [Export]
    private Slider HandsScale;
    [Export]
    private Slider BodyOrnamentScale;
    [Export]
    private Slider BodyOrnamentDynamic;

    //
    // Legs
    //

    [ExportGroup("Leg Props")]
    [Export]
    private Slider LegsScale;
    [Export]
    private Slider LegsOrnamentDynamic;

    //
    // Other things
    //

    [Export]
    private OptionButton HeadSelection { get; set; }
    [Export]
    private PackedScene[] Heads { get; set; }

    public override void _Ready()
    {
        Head = GetNode<PuppetHead>("Head") ?? throw new Exception("Node 'Head' not found");

        // TODO: None of these handler map to the right Head/Puppet properties yet
        if (EyeLeftSize is not null) EyeLeftSize.ValueChanged += (v) => Head.EyeOffset = v;
        if (EyeRightSize is not null) EyeRightSize.ValueChanged += (v) => Head.EyeRotation = v;
        if (EyeLeftRotation is not null) EyeLeftRotation.ValueChanged += (v) => Head.EyeOffset = v;
        if (EyeRightRotation is not null) EyeRightRotation.ValueChanged += (v) => Head.EyeRotation = v;
        if (EyeGap is not null) EyeGap.ValueChanged += (v) => Head.EyeOffset = v;
        if (EyeDrift is not null) EyeDrift.ValueChanged += (v) => Head.EyeRotation = v;

        if (MouthPosition is not null) MouthPosition.ValueChanged += (v) => Head.EyeRotation = v;
        if (MouthWidth is not null) MouthWidth.ValueChanged += (v) => Head.EyeRotation = v;
        if (MouthHeight is not null) MouthHeight.ValueChanged += (v) => Head.EyeRotation = v;
        if (MouthRotation is not null) MouthRotation.ValueChanged += (v) => Head.EyeRotation = v;

        if (ChinStretch is not null) ChinStretch.ValueChanged += (v) => Head.EyeRotation = v;
        if (ChinWidth is not null) ChinWidth.ValueChanged += (v) => Head.EyeRotation = v;
        // Unimplemented
        // if (ChinElasticity is not null) ChinElasticity.ValueChanged += (v) => Head.EyeRotation = v;

        if (HeadBaseWidth is not null) HeadBaseWidth.ValueChanged += (v) => Head.EyeRotation = v;
        if (HeadBaseHeight is not null) HeadBaseHeight.ValueChanged += (v) => Head.EyeRotation = v;
        if (HeadOrnamentDynamic is not null) HeadOrnamentDynamic.ValueChanged += (v) => Head.EyeRotation = v;

        // Body events

        if (LeftArmLength is not null) LeftArmLength.ValueChanged += (v) => Head.EyeRotation = v;
        if (RightArmLength is not null) RightArmLength.ValueChanged += (v) => Head.EyeRotation = v;
        if (ArmElasticity is not null) ArmElasticity.ValueChanged += (v) => Head.EyeRotation = v;
        if (HandsScale is not null) HandsScale.ValueChanged += (v) => Head.EyeRotation = v;
        if (BodyOrnamentScale is not null) BodyOrnamentScale.ValueChanged += (v) => Head.EyeRotation = v;
        if (BodyOrnamentDynamic is not null) BodyOrnamentDynamic.ValueChanged += (v) => Head.EyeRotation = v;

        // Legs

        if (LegsScale is not null) LegsScale.ValueChanged += (v) => Head.EyeRotation = v;
        if (LegsOrnamentDynamic is not null) LegsOrnamentDynamic.ValueChanged += (v) => Head.EyeRotation = v;

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
            head.EyeOffset = EyeLeftSize.Value;
            head.EyeRotation = EyeLeftRotation.Value;
        }
        else
        {
            GD.Print($"Invalid puppet head scene at element {index}");
        }
    }
}
