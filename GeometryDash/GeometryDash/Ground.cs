using System;
using IUTGame;

namespace GeometryDash;

public class Ground : GameItem, IAnimable
{
    
    public override string TypeName => "ground";
    
    public Ground(double x, double y, Game game)
        : base(x, y, game, "background\\groundSquare_01_001-hd.png", 2)
    {
        //this.ChangeScale(0.5, 0.5);
        MoveXY(0 , TheGame.Screen.Height - this.Height);
        Console.WriteLine("Height: " + this.Height);
        Console.WriteLine("Width: " + this.Width);
        this.Collidable = true;
    }

    public override void CollideEffect(GameItem other)
    {
    }


    public void Animate(TimeSpan dt)
    {
    }
}