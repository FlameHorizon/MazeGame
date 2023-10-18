// The goal of this project it to build a game where player
// tries to escape a maze.

// - Draw a maze onto console. Maze will be represented by characters between
// 2500 and 257F - https://www.unicode.org/charts/PDF/U2500.pdf

// Draw just a 4x4 simple box

DrawBox(10);

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