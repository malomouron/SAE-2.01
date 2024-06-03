using System;
using System.Numerics;
using System.Windows.Input;
using IUTGame;
using TD03;

namespace GeometryDash;

public class Cube: GameItem, IAnimable, IKeyboardInteract, IMouseInteract
{
    
    public override string TypeName => "cube";
    

    private Vector2D _speed = new Vector2D(0, 0);
    private static double _mass = 1;

    private static Vector2D _gravity = new Vector2D(0, (981.00*_mass));
    private Vector2D _accel = _gravity * (1 / _mass);
    
    const double _jumpSpeed = 800;
    
    private bool _grounded = false;
    private double _groundY = double.PositiveInfinity;
    
    
    
    public Cube(double x, double y, Game game)
        : base(x, y, game, "balle.png", 1)
    {
        this.Collidable = true;
    }


    public override void CollideEffect(GameItem other)
    {
        if (other.TypeName == "ground")
        {
            _groundY = other.Top;
            _grounded = true;
        }
    }

    
    public void Animate(TimeSpan dt)
    {
        Vector2D speedDifference;

        if (!_grounded)
        {
            speedDifference = _accel * dt.TotalSeconds;
            _speed += speedDifference;
        }   
        else
        {
            _speed = new Vector2D(0, 0);
        }

        Vector2D posDifference = _speed * dt.TotalSeconds;
        MoveXY(posDifference.X, posDifference.Y);
        Console.WriteLine(_groundY+ " " + Bottom);
        if ( _groundY < Bottom)
        {
            MoveXY(0, _groundY-Bottom);
        }
    }

    private void Jump()
    {
        if (_grounded)
        {
            _grounded = false;
            _speed = new Vector2D(_speed.X, -_jumpSpeed);
        }
    }

    public void KeyUp(Key key)
    {
    }

    public void KeyDown(Key key)
    {
        if (key == Key.Space)
        {
            Jump();
        }
    }

    public void MouseMoved(double x, double y)
    {
    }

    public void MouseLeftButtonDown(double x, double y)
    {
        Jump();
    }

    public void MouseLeftButtonUp(double x, double y)
    {
    }

    public void MouseRightButtonDown(double x, double y)
    {
    }

    public void MouseRightButtonUp(double x, double y)
    {
    }

    public void MouseWheel(int delta)
    {
    }
}