using Godot;
using System;

public partial class Player : CharacterBody2D {
	public int Speed = 400;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Vector2.Zero;

		if (Input.IsActionPressed("ui_left"))
		velocity.X -= 1;
		if (Input.IsActionPressed("ui_right"))
		velocity.X += 1;

		Velocity = velocity * Speed;
		MoveAndSlide();

		var screenWidth = GetViewport().GetVisibleRect().Size.X;
		Position = new Vector2(Mathf.Clamp(Position.X, 0, screenWidth), Position.Y);
	}
}