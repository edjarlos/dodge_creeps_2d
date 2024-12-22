using Godot;
using System;

public partial class Player : Area2D
{
	//Re-build everytime there is a new export variable/signal
	[Export]
	public int speed { get; set; } = 400; //How fast the player will move (pixels/sec)

	public Vector2 Screensize; //Size of the game window

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Screensize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;

		if (Input.IsActionPressed("move_right"))
		{
			velocity.X += 1;
		}
		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= 1;
		}
		if (Input.IsActionPressed("move_up"))
		{
			velocity.Y -= 1;
		}
		if (Input.IsActionPressed("move_down"))
		{
			velocity.Y += 1;
		}

		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * speed;
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Stop();
		}

		Position += velocity * (float)delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, Screensize.X),
			y: Mathf.Clamp(Position.Y, 0, Screensize.Y)
		);
	}
}
