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
	[Export] public int MaxScore = 20;

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
		AddChild(item);

		// edellinen osa koodia
		// var viewportWidth = GetViewport().GetVisibleRect().Size.X;
		// item.Position = new Vector2((float)GD.RandRange(0, viewportWidth), 50);

		float spawnMinX = 100;
		float spawnMaxX = 800;
		float randomX = (float)GD.RandRange(spawnMinX, spawnMaxX);
		item.Position = new Vector2(randomX, 50);

		//edellinen osa koodia testinä
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

		if (score >= MaxScore)
		{
			EndGame(); // huudellaan metodia
		}

	}

	private void EndGame()
	{
		GD.Print("Peli päättyi, maksimipistemäärä saavutettu");
		GetTree().Paused = true; // pysäyttää pelin

	}
}