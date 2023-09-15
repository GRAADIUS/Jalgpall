using System;

namespace Football;

public class Player
{
    public string Name { get; } // Just say my name
    public double X { get; private set; } // hell, where i am
    public double Y { get; private set; } // again!?
    private double _vx, _vy; // to this sword vx, vy meters
    public Team? Team { get; set; } = null; // It's my team, and it's my family

    private const double MaxSpeed = 5; // why I so slow?
    private const double MaxKickSpeed = 25; // No! My leggs! a haven't leggs!
    private const double BallKickDistance = 10; // Why balls cann't fly?

    private Random _random = new Random(); // Oh no! RND!
    // I like lego!
    public Player(string name) // I now his name, but i dont now his team...
    {
        Name = name;
    }

    public Player(string name, double x, double y, Team team) // now I know what team he's on
    {
        Name = name;
        X = x;
        Y = y;
        Team = team;
    }

    public void SetPosition(double x, double y) // you need move here
    {
        X = x;
        Y = y;
    }

    public (double, double) GetAbsolutePosition() // Hay! what team are you from?! And go on you'r field!
    {
        return Team!.Game.GetPositionForTeam(Team, X, Y);
    }

    public double GetDistanceToBall() // use a brain, and match what distance for the ball
    {
        var ballPosition = Team!.GetBallPosition();
        var dx = ballPosition.Item1 - X;
        var dy = ballPosition.Item2 - Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public void MoveTowardsBall() // run for ball
    {
        var ballPosition = Team!.GetBallPosition();
        var dx = ballPosition.Item1 - X;
        var dy = ballPosition.Item2 - Y;
        var ratio = Math.Sqrt(dx * dx + dy * dy) / MaxSpeed;
        _vx = dx / ratio;
        _vy = dy / ratio;
    }

    public void Move() // you can move?
    {
        if (Team.GetClosestPlayerToBall() != this)
        {
            _vx = 0;
            _vy = 0;
        }

        if (GetDistanceToBall() < BallKickDistance) // ti daleko, ne bej dadja
        {
            Team.SetBallSpeed(
                MaxKickSpeed * _random.NextDouble(),
                MaxKickSpeed * (_random.NextDouble() - 0.5)
                );
        }

        var newX = X + _vx;
        var newY = Y + _vy;
        var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY);
        if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2))
        {
            X = newX;
            Y = newY;
        }
        else
        {
            _vx = _vy = 0;
        }
    }
}