using System;
using System.Drawing;
using System.Linq;
namespace Tetris
{
    public class Element
    {
        int StateRotate = 0;
        Random Rnd = new Random();
        public ElementStruct CurrentElement;
        public GameFieldBoard GameField;
        int WIDTH;
        int HEIGHT;
        public Element(int WIDTH, int HEIGHT, GameFieldBoard gameField)
        {
            this.WIDTH = WIDTH;
            this.HEIGHT = HEIGHT;
            GameField = gameField;
        }
        public Point[] ConvertElementCordInAbsolute(ElementStruct Element)
        {
            Point[] ResultPoint = new Point[Element.ElementSize];
            int ResultIndex = 0;
            int IndexElementOnY = 0;
            for (int y = 0; y < Element.Element.GetLength(0); y++)
            {
                int IndexElementOnX = 0;
                for (int x = 0; x < Element.Element.GetLength(1); x++)
                {
                    if (Element.Element[y, x] == 1)
                    {
                        ResultPoint[ResultIndex] = new Point(Element.X + IndexElementOnX, Element.Y + IndexElementOnY);
                        ResultIndex++;
                    }
                    IndexElementOnX++;
                }
                IndexElementOnY++;
            }
            return ResultPoint;
        }
        public void ChangePosElement(int x, int y)
        {
            Point[] OldPos = ConvertElementCordInAbsolute(CurrentElement);
            foreach (var OldPosPoint in OldPos)
            {
                GameField.SetPoint(OldPosPoint.X,OldPosPoint.Y, ' ');
            }
            if (x == 1 || x == -1)
            {

                ElementStruct TempElement = CurrentElement;
                TempElement.X += x;
                if (GameField.IsNotBlock(ConvertElementCordInAbsolute(TempElement)))
                {
                    CurrentElement.X += x;
                }
            }
            if (y == 1)
            {
                ElementStruct TempElement = CurrentElement;
                TempElement.Y += y;
                if (GameField.IsNotBlock(ConvertElementCordInAbsolute(TempElement)))
                {
                    CurrentElement.Y += y;
                }
                foreach (var PointCurrentElement in ConvertElementCordInAbsolute(CurrentElement))
                {
                    if (GameField.BorderPos.Where(point => point.Y == PointCurrentElement.Y + 1 && point.X == PointCurrentElement.X).Count() > 0)
                    {
                        GameField.BorderPos.AddRange(ConvertElementCordInAbsolute(CurrentElement));
                        Point[] PointElement = ConvertElementCordInAbsolute(CurrentElement);
                        for (int Y = 0; Y < HEIGHT; Y++)
                        {
                            for (int X = 0; X < WIDTH; X++)
                            {
                                foreach (var Point in PointElement)
                                {
                                    if (X == Point.X && Y == Point.Y)
                                    {
                                        GameField.SetPoint(X,Y, '#');
                                    }
                                }
                            }
                        }

                        GenerateNewElement();
                        break;
                    }
                }

            }
            Point[] NewPos = ConvertElementCordInAbsolute(CurrentElement);
            foreach (var NewPosPoint in NewPos)
            {
                GameField.SetPoint(NewPosPoint.X,NewPosPoint.Y, '#');
            }

        }
        public void Rotate()
        {
            if (CurrentElement.TypeElement == ElementType.Stick)
            {
                if (StateRotate == 0)
                {
                    int[,] Element = new int[4, 1];
                    Element[0, 0] = 1;
                    Element[1, 0] = 1;
                    Element[2, 0] = 1;
                    Element[3, 0] = 1;

                    GameField.DeletePoints(ConvertElementCordInAbsolute(CurrentElement));


                    CurrentElement = new ElementStruct
                    {
                        Element = Element,
                        ElementSize = 4,
                        X = CurrentElement.X,
                        Y = CurrentElement.Y,
                        TypeElement = CurrentElement.TypeElement
                    };
                    StateRotate++;
                    GameField.SetPoints(ConvertElementCordInAbsolute(CurrentElement));
                }
                else if (StateRotate == 1)
                {
                    int[,] Element = new int[2, 4];
                    Element[0, 0] = 1;
                    Element[0, 1] = 1;
                    Element[0, 2] = 1;
                    Element[0, 3] = 1;
                    Element[1, 0] = 0;
                    Element[1, 1] = 0;
                    Element[1, 2] = 0;

                    GameField.DeletePoints(ConvertElementCordInAbsolute(CurrentElement));


                    CurrentElement = new ElementStruct
                    {
                        Element = Element,
                        ElementSize = 4,
                        X = CurrentElement.X,
                        Y = CurrentElement.Y,
                        TypeElement = CurrentElement.TypeElement
                    };
                    StateRotate = 0;
                    GameField.SetPoints(ConvertElementCordInAbsolute(CurrentElement));
                }

            }
            else if (CurrentElement.TypeElement == ElementType.T)
            {
                if (StateRotate == 0)
                {
                    int[,] Element = new int[3, 2];
                    Element[0, 0] = 1;
                    Element[1, 0] = 1;
                    Element[2, 0] = 1;
                    Element[1, 1] = 1;

                    GameField.DeletePoints(ConvertElementCordInAbsolute(CurrentElement));


                    CurrentElement = new ElementStruct
                    {
                        Element = Element,
                        ElementSize = 4,
                        X = CurrentElement.X,
                        Y = CurrentElement.Y,
                        TypeElement = CurrentElement.TypeElement
                    };
                    StateRotate++;
                    GameField.SetPoints(ConvertElementCordInAbsolute(CurrentElement));
                }
                else if (StateRotate == 1)
                {
                    int[,] Element = new int[2, 3];
                    Element[1, 0] = 1;
                    Element[1, 1] = 1;
                    Element[1, 2] = 1;
                    Element[0, 1] = 1;

                    GameField.DeletePoints(ConvertElementCordInAbsolute(CurrentElement));


                    CurrentElement = new ElementStruct
                    {
                        Element = Element,
                        ElementSize = 4,
                        X = CurrentElement.X,
                        Y = CurrentElement.Y,
                        TypeElement = CurrentElement.TypeElement
                    };
                    StateRotate++;
                    GameField.SetPoints(ConvertElementCordInAbsolute(CurrentElement));
                }
                else if (StateRotate == 2)
                {
                    int[,] Element = new int[3, 2];
                    Element[1, 0] = 1;
                    Element[0, 1] = 1;
                    Element[1, 1] = 1;
                    Element[2, 1] = 1;

                    GameField.DeletePoints(ConvertElementCordInAbsolute(CurrentElement));


                    CurrentElement = new ElementStruct
                    {
                        Element = Element,
                        ElementSize = 4,
                        X = CurrentElement.X,
                        Y = CurrentElement.Y,
                        TypeElement = CurrentElement.TypeElement
                    };
                    StateRotate++;
                    GameField.SetPoints(ConvertElementCordInAbsolute(CurrentElement));
                }
                else
                {
                    int[,] Element = new int[2, 3];
                    Element[0, 0] = 1;
                    Element[0, 1] = 1;
                    Element[0, 2] = 1;
                    Element[1, 1] = 1;
                    GameField.DeletePoints(ConvertElementCordInAbsolute(CurrentElement));


                    CurrentElement = new ElementStruct
                    {
                        Element = Element,
                        ElementSize = 4,
                        X = CurrentElement.X,
                        Y = CurrentElement.Y,
                        TypeElement = CurrentElement.TypeElement
                    };
                    StateRotate = 0;
                    GameField.SetPoints(ConvertElementCordInAbsolute(CurrentElement));

                }
            }
            else if (CurrentElement.TypeElement == ElementType.L)
            {
                if (StateRotate == 0)
                {
                    int[,] Element = new int[2, 3];
                    Element[1, 0] = 1;
                    Element[1, 1] = 1;
                    Element[1, 2] = 1;
                    Element[0, 2] = 1;
                    GameField.DeletePoints(ConvertElementCordInAbsolute(CurrentElement));


                    CurrentElement = new ElementStruct
                    {
                        Element = Element,
                        ElementSize = 4,
                        X = CurrentElement.X,
                        Y = CurrentElement.Y,
                        TypeElement = CurrentElement.TypeElement
                    };
                    StateRotate++;
                    GameField.SetPoints(ConvertElementCordInAbsolute(CurrentElement));
                }
                else if (StateRotate == 1)
                {

                    int[,] Element = new int[3, 2];
                    Element[0, 0] = 1;
                    Element[0, 1] = 1;
                    Element[1, 1] = 1;
                    Element[2, 1] = 1;
                    GameField.DeletePoints(ConvertElementCordInAbsolute(CurrentElement));


                    CurrentElement = new ElementStruct
                    {
                        Element = Element,
                        ElementSize = 4,
                        X = CurrentElement.X,
                        Y = CurrentElement.Y,
                        TypeElement = CurrentElement.TypeElement
                    };
                    StateRotate++;
                    GameField.SetPoints(ConvertElementCordInAbsolute(CurrentElement));
                }
                else if (StateRotate == 2)
                {
                    int[,] Element = new int[2, 3];
                    Element[0, 0] = 1;
                    Element[1, 0] = 1;
                    Element[0, 1] = 1;
                    Element[0, 2] = 1;
                    GameField.DeletePoints(ConvertElementCordInAbsolute(CurrentElement));


                    CurrentElement = new ElementStruct
                    {
                        Element = Element,
                        ElementSize = 4,
                        X = CurrentElement.X,
                        Y = CurrentElement.Y,
                        TypeElement = CurrentElement.TypeElement
                    };
                    StateRotate++;
                    GameField.SetPoints(ConvertElementCordInAbsolute(CurrentElement));
                }
                else if (StateRotate == 3)
                {
                    int[,] Element = new int[3, 2];
                    Element[0, 0] = 1;
                    Element[1, 0] = 1;
                    Element[2, 0] = 1;
                    Element[2, 1] = 1;
                    GameField.DeletePoints(ConvertElementCordInAbsolute(CurrentElement));


                    CurrentElement = new ElementStruct
                    {
                        Element = Element,
                        ElementSize = 4,
                        X = CurrentElement.X,
                        Y = CurrentElement.Y,
                        TypeElement = CurrentElement.TypeElement
                    };
                    StateRotate = 0;
                    GameField.SetPoints(ConvertElementCordInAbsolute(CurrentElement));
                }
            }

        }
        public void GenerateNewElement()
        {
            StateRotate = 0;
            int CurrentElementNumber = Rnd.Next(0, 4);
            ElementType ElementType;
            int Size = 4;
            int[,] Element;
            if (CurrentElementNumber == 0)
            {
                Element = new int[2, 4];
                Element[0, 0] = 1;
                Element[0, 1] = 1;
                Element[0, 2] = 1;
                Element[0, 3] = 1;
                Element[1, 0] = 0;
                Element[1, 1] = 0;
                Element[1, 2] = 0;
                ElementType = ElementType.Stick;
            }
            else if (CurrentElementNumber == 1)
            {
                Element = new int[2, 2];
                Element[0, 0] = 1;
                Element[0, 1] = 1;
                Element[1, 1] = 1;
                Element[1, 0] = 1;
                ElementType = ElementType.Cube;
            }
            else if (CurrentElementNumber == 2)
            {
                Element = new int[3, 2];
                Element[0, 0] = 1;
                Element[1, 0] = 1;
                Element[2, 0] = 1;
                Element[2, 1] = 1;
                Size = 4;
                ElementType = ElementType.L;

            }
            else
            {
                Element = new int[2, 3];
                Element[0, 0] = 1;
                Element[0, 1] = 1;
                Element[0, 2] = 1;
                Element[1, 1] = 1;
                ElementType = ElementType.T;
            }
            CurrentElement = new ElementStruct()
            {
                Element = Element,
                X = Rnd.Next(1, WIDTH - 2),
                Y = 0,
                ElementSize = Size,
                TypeElement = ElementType
            };

            for (int y = 0; y < HEIGHT; y++)
            {
                bool LineFilled = false;
                for (int x = 0; x < WIDTH; x++)
                {
                    if (GameField.GameField[y][x] == '#')
                    {
                        LineFilled = true;
                    }
                    else if (GameField.GameField[y][x] == ' ')
                    {
                        LineFilled = false;
                        break;
                    }
                }
                if (LineFilled)
                {
                    for (int XLine = 1; XLine < WIDTH - 1; XLine++)
                    {
                        GameField.SetPoint(XLine, y, ' ');
                        GameField.BorderPos.Remove(new Point(XLine, y));
                        for (int YLine = y; YLine > 0; YLine--)
                        {



                            GameField.SetPoint(XLine, YLine, GameField.GameField[YLine - 1][XLine]);
                            if (GameField.GameField[YLine][XLine] == '#')
                            {
                                if (!GameField.BorderPos.Contains(new Point(XLine, YLine)))
                                {
                                    GameField.BorderPos.Add(new Point(XLine, YLine));
                                }
                            }
                            else
                            {
                                GameField.BorderPos.Remove(new Point(XLine, YLine));
                            }
                            GameField.SetPoint(XLine, YLine - 1, ' ');



                        }
                    }
                }
            }
        }
    }

    public enum ElementType
    {
        Stick,
        Cube,
        L,
        T
    }
    public struct ElementStruct
    {

        public int[,] Element { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int ElementSize { get; set; }
        public ElementType TypeElement { get; set; }
    }
}
