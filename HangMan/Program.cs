using System;

namespace HangMan
{
    class Program
    {
        static bool guessedAll(char[] solution, char[] guesses)
        {
            int correct = 0;

            for (int i = 0; i < solution.Length; i++)
            {
                if (solution[i] == guesses[i])
                {
                    correct++;
                }
            }

            return correct == solution.Length;
        }

        static char[] guessedString(char[] guesses)
        {
            char[] result = new char[guesses.Length];

            for (int i = 0; i < guesses.Length; i++)
            {
                if ((int) guesses[i] == 0)
                {
                    result[i] = '_';
                } else
                {
                    result[i] = guesses[i];
                }
            }

            return result;
        }

        static void writeGuessed(char[] guesses, int[] textPosition)
        {
            int[] oldPosition  = { Console.CursorLeft, Console.CursorTop };
            string text = String.Join(' ', guessedString(guesses));


            Console.SetCursorPosition(textPosition[0], textPosition[1]);
            Console.Write(text);
            Console.SetCursorPosition(oldPosition[0], oldPosition[1]);
        }

        static void Main(string[] args)
        {
            String word;
            int lives = 7;

            Console.Write("Enter the word: ");

            Console.ForegroundColor = ConsoleColor.Black;
            word = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            int[] guessesPosition = new int[] { Console.WindowWidth / 2, (Console.WindowHeight / 2) + 15 };
            HangMan hangMan = new HangMan(new int[] { Console.WindowWidth / 2, Console.WindowHeight / 2 }, new int[] { Console.WindowWidth / 2, (Console.WindowHeight / 2) + 20 });

            Console.Write("Guess 1 letter at a time: ");

            char[] solution = word.ToCharArray();
            char[] guesses = new char[solution.Length];
            
            writeGuessed(guesses, guessesPosition);

            while (!guessedAll(solution, guesses) && lives > 0)
            {
                char input = Console.ReadKey().KeyChar;
                bool correct = false;

                for (int i = 0; i < solution.Length; i++)
                {
                    if (input == solution[i])
                    {
                        if ((int) guesses[i] == 0)
                        {
                            guesses[i] = input;
                            correct = true;
                        }
                    }
                }

                if (correct == true)
                {
                    writeGuessed(guesses, guessesPosition);
                } else
                {
                    lives--;

                    hangMan.drawNext();
                }
            }

            if (lives > 0)
            {
                hangMan.gameWon();
            } else
            {
                hangMan.gameDied();

                int[] position = guessesPosition;

                position[1] += 1;

                writeGuessed(solution, position);
            }

            while (true) { }
        }
    }
}
