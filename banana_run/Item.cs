using Godot;
using System;

public partial class Item : Area2D
{
	[Export]
	public int FallSpeed = 200;

	public override void _Process(double delta)
	{
		Position += new Vector2(0, FallSpeed * (float)delta);

		if (Position.Y > GetViewport().GetVisibleRect().Size.Y)
			QueueFree(); //Poistaa esineen, kun se menee pois ruudulta
	}

	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}

	private void OnBodyEntered(Node body)
	{
		if (body is Player)
		{
			Main.Manager.IncreaseScore();
			QueueFree(); // Poistaa kerätyn esineen
		}
	}
}