using System;

namespace HangMan
{
    public class HangMan
    {
        int[] pencilTip;
        int[] textPos;

        int i = 0;

        public HangMan(int[] rootPos, int[] textPos)
        {
            this.pencilTip = rootPos;
            this.textPos = textPos;
        }
            
        public void gameWon()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(textPos[0], textPos[1]);
            Console.WriteLine("You guessed the word!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void gameDied()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(textPos[0], textPos[1]);
            Console.WriteLine("You died!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void drawStand()
        {
            Console.SetCursorPosition(pencilTip[0], pencilTip[1]);
            Console.Write("------");
        }

        public void drawPole()
        {
            Console.SetCursorPosition(pencilTip[0] += 2, pencilTip[1] -= 1);

            for (int i = 0; i < 10; i++)
            {
                Console.Write("|");
                Console.SetCursorPosition(pencilTip[0], pencilTip[1] -= 1);
            }
        }

        public void drawRoof()
        {
            Console.SetCursorPosition(pencilTip[0], pencilTip[1]);
            Console.Write("------------");
            Console.SetCursorPosition(pencilTip[0] += ("------------".Length - 1), pencilTip[1]);
        }

        public void drawRope()
        {
            for (int i = 0; i < 2; i++)
            {

                Console.SetCursorPosition(pencilTip[0], pencilTip[1] += 1);
                Console.Write("|");
            }
        }

        public void drawHead()
        {
            Console.SetCursorPosition(pencilTip[0] -= 1, pencilTip[1] += 1);
            Console.Write("<<)");
        }

        public void drawBody()
        {
            Console.SetCursorPosition(pencilTip[0] += 1, pencilTip[1] += 1);
            Console.Write("#");

            Console.SetCursorPosition(pencilTip[0] -= 4, pencilTip[1] += 1);
            Console.Write("=-- # --=");

            Console.SetCursorPosition(pencilTip[0] += 4, pencilTip[1] += 1);
            Console.Write("#");
        }

        public void drawLegs()
        {

            Console.SetCursorPosition(pencilTip[0] -= 1, pencilTip[1] += 1);
            Console.Write("/ \\");

            Console.SetCursorPosition(pencilTip[0] -= 2, pencilTip[1] += 1);
            Console.Write("_/   \\_");
        }

        public void drawNext()
        {
            int[] position = { Console.CursorLeft, Console.CursorTop };

            switch (i)
            {
                case 0:
                    this.drawStand();
                    break;

                case 1:
                    this.drawPole();
                    break;

                case 2:
                    this.drawRoof();
                    break;

                case 3:
                    this.drawRope();
                    break;

                case 4:
                    this.drawHead();
                    break;

                case 5:
                    this.drawBody();
                    break;

                case 6:
                    this.drawLegs();
                    break;
            }

            Console.SetCursorPosition(position[0], position[1]);

            i++;
        }
    }
}
