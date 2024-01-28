using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace ggj2024;
public static class Extensions
{
    /// <summary>
    /// Checks if a node has a child of type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">Type of child to search for</typeparam>
    /// <param name="node"></param>
    /// <param name="firstResult">Child of type <typeparamref name="T"/> or null</param>
    /// <param name="recursive">Recurse breadth-first through children</param>
    /// <returns>True if found</returns>
    public static Boolean HasChildOfType<T>(this Node node, out T firstResult, bool recursive = false) where T : Node
    {
        var children = node.GetChildren();
        var tBoy = children.FirstOrDefault((c) => c is T) as T;

        if (tBoy is null && recursive is true)
        {
            foreach (var check in children)
            {
                if (check.HasChildOfType(out T child, recursive))
                {
                    firstResult = child;
                    return true;
                }
            }

            firstResult = null;
            return false;
        }
        else
        {
            firstResult = tBoy;
            return true;
        }
    }
}
