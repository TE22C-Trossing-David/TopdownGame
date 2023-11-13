using Raylib_cs;
using System.Numerics;

int screenSizeX = 1920 / 2;
int screenSizeY = 1080 / 2;

string scene = "start";
int bollX = 100;
int bollY = 100;
int winX = 500;
int winY = 300;

string start = "start with space";

Raylib.InitWindow(screenSizeX, screenSizeY, "Yooooo");

Random rnd = new Random();
int num = rnd.Next();


Rectangle psykadeliskBoll = new Rectangle(bollX, bollY, 100, 100);
Rectangle win = new Rectangle(winX, winY, 50, 50);



while (!Raylib.WindowShouldClose())
{
    if (scene == "start")
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.BeginDrawing();
        Raylib.DrawText(start, screenSizeX/3, screenSizeY/3, 20, Color.DARKBLUE);
        Raylib.EndDrawing();
        if(Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
        }
    }
    if (scene == "game")
    {

        //random color
        Color random = new Color(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), 255);


        Raylib.ClearBackground(Color.BLACK);
        Raylib.SetTargetFPS(2147483647);
        Raylib.BeginDrawing();
        Raylib.DrawFPS(10, 10);
        Raylib.DrawRectangle((int)psykadeliskBoll.x, (int)psykadeliskBoll.y, (int)psykadeliskBoll.height, (int)psykadeliskBoll.width, random);
        Raylib.DrawRectangle((int)win.x, (int)win.y, (int)win.height, (int)win.width, Color.WHITE);
        Raylib.EndDrawing();


        //movement 
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) || Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            psykadeliskBoll.x -= 1;
            Console.WriteLine(bollX);
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) || Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            psykadeliskBoll.x += 1;
            Console.WriteLine(bollX);
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP) || Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            psykadeliskBoll.y -= 1;
            Console.WriteLine(bollY);
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) || Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            psykadeliskBoll.y += 1;
            Console.WriteLine(bollY);
        }

        //collision win
        if (Raylib.CheckCollisionRecs(psykadeliskBoll, win))
        {
            scene = "win";
        }
    }
    if (scene == "win")
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawText("You won!", screenSizeX / 2, screenSizeY / 2, 5, Color.BEIGE);
        Raylib.EndDrawing();
    }

}