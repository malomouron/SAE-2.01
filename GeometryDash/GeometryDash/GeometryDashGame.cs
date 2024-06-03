using System;
using System.Linq;
using System.Numerics;
using IUTGame;

namespace GeometryDash;


public class GeometryDashGame : IUTGame.Game
{

    public GeometryDashGame(IScreen screen) : base(screen, "sprites", "sounds", 200)
    {
        
    }

    protected override void InitItems()
    {
        Cube cube = new Cube(this.Screen.Width / 2, 10, this);
        Ground ground = new Ground(0, 0, this);
        Background background = new Background(0, 0, this);
        this.AddItem(cube);
        this.AddItem(ground);
        this.AddItem(background);
        
    }

    protected override void RunWhenWin()
    {
    }

    protected override void RunWhenLoose()
    {
    }
    

}