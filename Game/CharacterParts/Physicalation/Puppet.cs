using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace ggj2024.CharacterParts.Physicalation;

public partial class Puppet : Node2D
{
    [Export]
    private Godot.Collections.Array<Godot.Range> Sliders = new() { null, null, null, null, null, null };
}
