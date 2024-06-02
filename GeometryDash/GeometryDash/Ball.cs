using System;
using System.Numerics;
using IUTGame;

namespace GeometryDash;

public class Ball: GameItem, IAnimable
{
    
    public override string TypeName => "ball";
    

    private Vector2 _speed = new Vector2(0, 0);
    private static double _mass = 1;

    private static Vector2 _gravity = new Vector2(0, (float)(981.00*_mass));
    private Vector2 _accel = _gravity * (float)(1 / _mass);
    
    private Vector2 _wind = new Vector2(30, 0);
    public Vector2 Wind
    {
        get => _wind;
        set => _wind = value;
    }
    
    public Ball(double x, double y, Game game)
        : base(x, y, game, "balle.png")
    {
    }


    public override void CollideEffect(GameItem other)
    {
        
    }

    
    public void Animate(TimeSpan dt)
    {
        
        Vector2 totalForce = _gravity + _wind;
        Vector2 newAccel = totalForce * (float)(1 / _mass);

        
        Vector2 speedDifference = newAccel * (float)dt.TotalSeconds;
        _speed += speedDifference;
        
        Vector2 posDifference = _speed * (float)dt.TotalSeconds;
        MoveXY(posDifference.X, posDifference.Y);
        
        
        if(Bottom>=TheGame.Screen.Height)
        {
            Bounce();
        }
        if (Right >= TheGame.Screen.Width || Left <= 0)
        {
            BounceWall();
        }

    }

    private void BounceWall()
    {
        _speed = new Vector2(-_speed.X, _speed.Y);
    }

    private void Bounce()
    {
        
        _speed = new Vector2(_speed.X, -_speed.Y);
        _speed *= 0.9f;
    }
}