using Godot;
using System;

public partial class Player : CharacterBody2D {
	public int Speed = 300;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Vector2.Zero;

		if (Input.IsActionPressed("ui_left"))
		velocity.X -= 1;
		if (Input.IsActionPressed("ui_right"))
		velocity.X += 1;

		Velocity = velocity * Speed;
		MoveAndSlide();
	}
}