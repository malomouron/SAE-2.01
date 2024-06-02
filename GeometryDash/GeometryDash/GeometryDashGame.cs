using IUTGame;

namespace GeometryDash;

public class GeometryDashGame : IUTGame.Game
{
    public GeometryDashGame(IScreen screen) : base(screen, "sprites", "sounds")
    {
        
    }

    protected override void InitItems()
    {
    }

    protected override void RunWhenWin()
    {
    }

    protected override void RunWhenLoose()
    {
    }
}