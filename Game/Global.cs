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
    /// <summary>
    /// IDK, but this way we don't have to hard code every single stat we may or may not want to store even though I don't like naked strings
    /// </summary>
    public static readonly Dictionary<String, StatValue> Stats = new();

    /// <summary>
    /// Stats dictionary value
    /// </summary>
    public interface StatValue { }

    public record NumberStat(Single Value) : StatValue;
    public record IntStat(Int32 Value) : StatValue;
    public record BooleanStat(Boolean Value) : StatValue;
    public record StringStat(String Value) : StatValue; 
    public record ObjectStat(Object Value) : StatValue;
    public record NodeStat(Node Value) : StatValue;
}