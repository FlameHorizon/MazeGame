// The goal of this project it to build a game where player
// tries to escape a maze.

// - Draw a maze onto console. Maze will be represented by characters between
// 2500 and 257F - https://www.unicode.org/charts/PDF/U2500.pdf

// Draw just a 4x4 simple box

var game = new Game();
Thread.Sleep(1000);
game.MoveDown();


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

    public Game()
    {
        _player = new Player
        {
            PosLeft = 1,
            PosTop = 1
        };
        InitializeBoard();
        Console.SetCursorPosition(_player.PosLeft, _player.PosTop);
        Console.Write("X");
    }

    private void InitializeBoard()
    {
        Console.Clear();
        DrawBox(4);

        void DrawBox(int edgeSize)
        {
            DrawTopLine(edgeSize);
            DrawSides(edgeSize);
            DrawBottomLine(edgeSize);
        }

        void DrawTopLine(int edgeSize)
        {
            // Draw top left corner
            Console.Write("╔");

            // Draw top strip. -2 because top left
            // and top right corner also counts as size
            for (var i = 0; i < edgeSize - 2; i++)
            {
                Console.Write("═");
            }

            Console.Write("╗" + Environment.NewLine);
        }

        void DrawSides(int edgeSize)
        {
            for (var i = 0; i < edgeSize - 2; i++)
            {
                Console.WriteLine($"║{new string(' ', edgeSize - 2)}║");
            }
        }

        void DrawBottomLine(int edgeSize)
        {
            // Draw bottom left corner
            Console.Write("╚");

            // Draw bottom strip. -2 because bottom left
            // and bottom right corner also counts as size
            for (var i = 0; i < edgeSize - 2; i++)
            {
                Console.Write("═");
            }

            Console.Write("╝" + Environment.NewLine);
        }

        // Drawing player icon.
        Console.CursorVisible = false;
    }

    public void MoveUp()
    {
        // Clear up previous position where player was.
        Console.SetCursorPosition(_player.PosLeft, _player.PosTop);
        Console.Write(" ");

        // Move player to a different location.
        _player.MoveUp();
        Console.SetCursorPosition(_player.PosLeft, _player.PosTop);
        Console.Write("X");
    }

    public void MoveDown()
    {
        // Clear up previous position where player was.
        Console.SetCursorPosition(_player.PosLeft, _player.PosTop);
        Console.Write(" ");

        // Move player to a different location.
        _player.MoveDown();
        Console.SetCursorPosition(_player.PosLeft, _player.PosTop);
        Console.Write("X");
    }
}