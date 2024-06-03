using IUTGame;

namespace GeometryDash;

public class Background : GameItem
{
    public Background(double x, double y, Game game)
        : base(x, y, game, "background\\game_bg_01_001-hd.png", 0)
    {
    }

    public override void CollideEffect(GameItem other)
    {
   
    }

    public override string TypeName => "background";
}