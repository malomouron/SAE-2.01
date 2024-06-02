using System;
using System.Linq;
using System.Numerics;
using IUTGame;

namespace GeometryDash;

public delegate void WindChangedEventHandler(double newWindValue);

public class GeometryDashGame : IUTGame.Game
{
    
    private double _wind2 = 0;
    public double Wind2
    {
        get => _wind2;
        set             
        {
            if (_wind2 != value)
            {
                _wind2 = value;
                OnWindChanged(_wind2);
            }
        }
    }
    
    public event WindChangedEventHandler WindChanged;

    public GeometryDashGame(IScreen screen) : base(screen, "sprites", "sounds", 200)
    {
        
    }

    protected override void InitItems()
    {
        Ball ball = new Ball(this.Screen.Width / 2, 10, this);
        this.AddItem(ball);
    }

    protected override void RunWhenWin()
    {
    }

    protected override void RunWhenLoose()
    {
    }
    
    protected virtual void OnWindChanged(double newWindValue)
    {
        WindChanged?.Invoke(newWindValue);
        Console.WriteLine("Wind: " + _wind2);
        GameItem ball = this.ListItems().FirstOrDefault(item => item.TypeName == "ball");    
        if (ball != null)
        {
            Ball b = (Ball) ball;
            b.Wind = new Vector2((float)_wind2, 0);
        }
    }

}