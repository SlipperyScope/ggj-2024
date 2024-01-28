using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace ggj2024.Obstacles;

[GlobalClass]
public partial class ParticlePooper : Node2D
{
    private class Particle
    {
        public Vector2 Position;
        public Single Radius;
        public Color Color;
        public Particle(Vector2 position, Single radius, Color color)
        {
            Position = position;
            Radius = radius;
            Color = color;
        }
    }

    private readonly List<Particle> Particles = new();

    private Timer[] Poopers = new Timer[5];

    public override void _Ready()
    {
        for (var i = 0; i < Poopers.Length; i++)
        {
            var pooper = new Timer
            {
                Autostart = true,
                OneShot = false,
                WaitTime = GD.Randf() * 1f + .25f,
            };

            AddChild(pooper);
            pooper.Timeout += MakeNewParticle;
        }
    }

    private void MakeNewParticle()
    {
        var particlePosition = /*Position + */new Vector2(Rand(), Rand());
        var particle = new Particle(particlePosition, Rand(20f, 50f), new Color(Colors.WhiteSmoke,Rand(0.2f,0.8f)));
        Particles.Add(particle);
    }

    private static Single Rand(Single min = -10f, Single max = 10f) => (Single)GD.RandRange(min, max);

    public override void _Process(Double delta)
    {
        QueueRedraw();
    }

    public override void _Draw()
    {
        var queueForDelete = new List<Particle>();
        var velChange = GetParentOrNull<RigidBody2D>()?.LinearVelocity ?? Vector2.Zero;
        foreach (var particle in Particles)
        {
            
            GD.Print($"position: {particle.Position}");
            DrawCircle(particle.Position, particle.Radius, particle.Color);

            if (particle.Position.X < 5000f)
            {
                queueForDelete.Add(particle);
            }
            else
            {
                particle.Position -= velChange;
            }
        }

        foreach(var dead in queueForDelete)
        {
            //Particles.Remove(dead);
        }
    }
}

