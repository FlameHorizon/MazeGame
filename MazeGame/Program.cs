// The goal of this project it to build a game where player
// tries to escape a maze.

// - Draw a maze onto console. Maze will be represented by characters between
// 2500 and 257F - https://www.unicode.org/charts/PDF/U2500.pdf

// Draw just a 4x4 simple box

var game = new Game();
Thread.Sleep(1000);
game.MoveUp();
Thread.Sleep(1000);
game.MoveDown();
Thread.Sleep(1000);
game.MoveRight();
Thread.Sleep(1000);
game.MoveLeft();


public class Player
{
    public int PosLeft { get; set; }
    public int PosTop { get; set; }

    public void MoveLeft()
    {
        PosLeft--;
    }

    public void MoveUp()
    {
        PosTop--;
    }

    public void MoveDown()
    {
        PosTop++;
    }

    public void MoveRight()
    {
        PosLeft++;
    }
}

public class Game
{
    private readonly Player _player;
    private string[,] _board;

    public Game()
    {
        _player = new Player
        {
            PosLeft = 1,
            PosTop = 1
        };
        InitializeBoard();
        DrawPlayerPosition();
    }

    private void DrawPlayerPosition()
    {
        Console.SetCursorPosition(_player.PosLeft, _player.PosTop);
        Console.Write("X");
    }

    private void InitializeBoard()
    {
        Console.Clear();
        _board = new string[4, 4];
        DrawBox(4);

        void DrawBox(int edgeSize)
        {
            CreateTopLine(edgeSize);
            CreateSides(edgeSize);
            CreateBottomLine(edgeSize);
            DrawBoard();
        }

        void CreateTopLine(int edgeSize)
        {
            _board[0, 0] = "╔";

            for (var i = 0; i < edgeSize - 2; i++)
            {
                _board[0, i + 1] = "═";
            }

            _board[0, edgeSize - 1] = "╗" + Environment.NewLine;
        }

        void CreateSides(int edgeSize)
        {
            for (var i = 1; i < edgeSize - 1; i++)
            {
                _board[i, 0] = "║";

                for (var j = 1; j < edgeSize - 1; j++)
                {
                    _board[i, j] = " ";
                }

                _board[i, edgeSize - 1] = "║" + Environment.NewLine;
            }
        }

        void CreateBottomLine(int edgeSize)
        {
            _board[edgeSize - 1, 0] = "╚";

            for (var i = 0; i < edgeSize - 2; i++)
            {
                _board[edgeSize - 1, i + 1] = "═";
            }

            _board[edgeSize - 1, edgeSize - 1] = "╝" + Environment.NewLine;
        }

        // Drawing player icon.
        Console.CursorVisible = false;
    }

    private void DrawBoard()
    {
        for (var row = 0; row < _board.GetLength(0); row++)
        {
            for (var column = 0; column < _board.GetLength(1); column++)
            {
                Console.Write(_board[row, column]);
            }
        }
    }

    public void MoveUp()
    {
        if (IsPlayerInBounds(MoveDirection.Up) == false)
        {
            // Player can't move there, there is a obstacle.
            return;
        }

        // Clear up previous position where player was.
        Console.SetCursorPosition(_player.PosLeft, _player.PosTop);
        Console.Write(" ");

        // Move player to a different location.
        _player.MoveUp();
        DrawPlayerPosition();
    }

    private bool IsPlayerInBounds(MoveDirection direction)
    {
        return direction switch
        {
            MoveDirection.Up => string.IsNullOrWhiteSpace(
                _board[_player.PosTop - 1, _player.PosLeft]),

            MoveDirection.Down => string.IsNullOrWhiteSpace(
                _board[_player.PosTop + 1, _player.PosLeft]),

            MoveDirection.Left => string.IsNullOrWhiteSpace(
                _board[_player.PosTop, _player.PosLeft - 1]),

            MoveDirection.Right => string.IsNullOrWhiteSpace(
                _board[_player.PosTop, _player.PosLeft + 1]),

            _ => false
        };
    }

    public void MoveDown()
    {
        if (IsPlayerInBounds(MoveDirection.Down) == false)
        {
            // Player can't move there, there is a obstacle.
            return;
        }

        // Clear up previous position where player was.
        Console.SetCursorPosition(_player.PosLeft, _player.PosTop);
        Console.Write(" ");

        // Move player to a different location.
        _player.MoveDown();
        DrawPlayerPosition();
    }

    public void MoveLeft()
    {
        if (IsPlayerInBounds(MoveDirection.Left) == false)
        {
            // Player can't move there, there is a obstacle.
            return;
        }
        
        // Clear up previous position where player was.
        Console.SetCursorPosition(_player.PosLeft, _player.PosTop);
        Console.Write(" ");

        // Move player to a different location.
        _player.MoveLeft();
        DrawPlayerPosition();
    }

    public void MoveRight()
    {
        if (IsPlayerInBounds(MoveDirection.Right) == false)
        {
            // Player can't move there, there is a obstacle.
            return;
        }
        
        // Clear up previous position where player was.
        Console.SetCursorPosition(_player.PosLeft, _player.PosTop);
        Console.Write(" ");

        // Move player to a different location.
        _player.MoveRight();
        DrawPlayerPosition();
    }
}

public enum MoveDirection
{
    Up,
    Down,
    Left,
    Right
}