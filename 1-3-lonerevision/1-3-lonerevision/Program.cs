using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3_lonerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSalaries;
            do
            {
                numberOfSalaries = ReadInt("Skrive in antal löner som ska behandlas: ");
                if (numberOfSalaries > 1)
                {
                    ProcessSalaries(numberOfSalaries);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Ange minst två löner för att en beräkning ska kunna göras!");
                }
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tryck tangent för ny beräkning - Esc avslutar.");
                Console.ResetColor();
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }


        private static int ReadInt(string prompt)
        {
            int returnValue;
            string input = "";

            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    input = Console.ReadLine();
                    returnValue = int.Parse(input);
                    break;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel! '{0}' kan inte tolkas som ett heltal.", input);
                    Console.ResetColor();
                }
            }
            return returnValue;

        }


        private static void ProcessSalaries(int count)
        {
            string textForReadInt;
            int[] salaries = new int[count];
            int[] copyOfSalaries = new int[count];

            
            for (int i = 0; i < count; i++)
            {
                textForReadInt = String.Format("Ange lön nummer {0}:", i + 1);

                // fixar så att man inte kan ha en negativ lön....
                salaries[i] = ReadInt(textForReadInt);
                if(salaries[i] < 0)
                {
                    Console.WriteLine("Det var ingen bra lön, försök igen..");
                    i = i - 1;
                }
            }


            Array.Copy(salaries, copyOfSalaries, count);
            Array.Sort(salaries);


            // Redovinsning:
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Medellön:\t{0,20:c0}", (int)salaries.Average());
            Console.WriteLine("Lönespridning:\t{0,20:c0}", salaries[count - 1] - salaries[0]);
            if(count % 2 != 0)
                {
                    Console.WriteLine("Medianlön:\t{0,20:c0}", salaries[count / 2]);
                }
            else
                {
                    Console.WriteLine("Medianlön:\t{0,20:c0}", (salaries[count / 2] + salaries[(count / 2) - 1]) / 2);
                }
            Console.WriteLine("----------------------------------------------");
            
            
            for (int i = 0; i < count / 3; i++)
            {
                Console.WriteLine("{0,12} {1,12} {2,12}", copyOfSalaries[i * 3], copyOfSalaries[(i * 3) + 1], copyOfSalaries[(i * 3) + 2]);
            }
            if(count % 3 > 1)
            {
                Console.WriteLine("{0,12} {1,12}", copyOfSalaries[count - 2], copyOfSalaries[count - 1]);
            }
            if (count % 3 == 1)
            {
                Console.WriteLine("{0,12}", copyOfSalaries[count - 1]);
            }
        }

    }
}
