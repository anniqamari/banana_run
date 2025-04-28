using Godot;
using System;

public partial class Main : Node2D
{
	private static Main _manager = null;
	public static Main Manager
	{
		get { return _manager; }
	}
	[Export] public PackedScene ItemScene;
	[Export] public Timer SpawnTimer;
	[Export] public Player Player;
	[Export] public Label ScoreLabel;

	private int score = 0;

	public Main()
	{
		_manager = this;
	}

	public override void _Ready()
	{
		SpawnTimer.Timeout += OnSpawnTimerTimeout;
		SpawnTimer.Start();
	}

	private void OnSpawnTimerTimeout()
	{
		var item = ItemScene.Instantiate<Item>();
		var viewportWidth = GetViewport().GetVisibleRect().Size.X;
		item.Position = new Vector2((float)GD.RandRange(0, viewportWidth), 50);
		GD.Print(item.Position);

		// item.BodyEntered += (Node2D body) =>
		// 	{
		// 		GD.Print("HELOOOLL");
		// 		IncreaseScore();
		// 		item.QueueFree();
		// 	};
	}

	public void IncreaseScore()
	{
		score += 1;
		ScoreLabel.Text = "Pisteet: " + score;
	}
}