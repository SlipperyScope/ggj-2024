using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
namespace ggj2024;

/// <summary>
/// Game jammy way to keep track of daters. Not even a singleton. Wow. Some people says it's an anti-pattern anyway
/// </summary>
public static class Global
{
    public static Single MaxDistance { get; set; }
    public static Single MaxHeight { get; set; }
    public static Single MaxTime { get; set; }
}