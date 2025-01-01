using Godot;
using System;

public partial class Main : Node
{
	// Called when the node enters the scene tree for the first time.

	[Export]
	public PackedScene Mobscene {get; set;}

	private int _score;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
