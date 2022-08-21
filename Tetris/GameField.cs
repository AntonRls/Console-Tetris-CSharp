using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace Tetris
{
    public class GameFieldBoard
    {
        public char[][] GameField;
        public int WIDTH;
        public int HEIGHT;

        public List<Point> BorderPos = new List<Point>();
        public GameFieldBoard(int WIDTH, int HEIGHT)
        {
            this.WIDTH = WIDTH;
            this.HEIGHT = HEIGHT;

            GameField = new char[HEIGHT][];
            for (int y = 0; y < HEIGHT; y++)
            {
                GameField[y] = new char[WIDTH];
                for (int x = 0; x < WIDTH; x++)
                {
                    if (x == 0 || x == WIDTH - 1)
                    {
                        GameField[y][x] = 'X';
                        BorderPos.Add(new Point(x, y));
                    }
                    else if (y == HEIGHT - 1)
                    {
                        GameField[y][x] = 'X';
                        BorderPos.Add(new Point(x, y));
                    }
                    else
                    {
                        GameField[y][x] = ' ';
                    }
                }
            }

        }
        public void SetPoints(Point[] points)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                for (int x = 0; x < WIDTH; x++)
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        if (points[i].X == x && points[i].Y == y)
                        {
                            GameField[y][x] = '#';
                        }
                    }
                }
            }
        }
        public void DeletePoints(Point[] points)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                for (int x = 0; x < WIDTH; x++)
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        if (points[i].X == x && points[i].Y == y)
                        {
                            GameField[y][x] = ' ';
                        }
                    }
                }
            }
        }
        public bool LineIsNotEmpty(int y)
        {
            for (int x = 1; x < WIDTH - 1; x++)
            {
                if (GameField[y][x] == '#')
                {
                    return true;
                }
            }
            return false;
        }
        public void SetPoint(int x, int y, char symbol)
        {
            GameField[y][x] = symbol;
        }
        public void DrawLevel()
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;


            for (int y = 0; y < HEIGHT; y++)
            {

                for (int x = 0; x < WIDTH; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(GameField[y][x]);
                }

            }
        }
        public bool IsNotBlock(Point[] pos) => BorderPos.Intersect(pos).Count() == 0;


    }
}
