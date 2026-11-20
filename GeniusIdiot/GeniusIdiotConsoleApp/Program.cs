using System;

public class MainClass
{
    public static void Main()
    {
        Console.WriteLine("Введите свое имя: ");
        int countStep = 5;
        string name = Console.ReadLine();
        while (true)
        {
            int countCorrectAnswer = AskQuestion(countStep);
            GettingResults(countCorrectAnswer, name);
            Console.WriteLine("Хотите сыграть ещё раз (Да / Нет):");
            if (Console.ReadLine() != "Да")
            {
                break;
            }

        }


    }

    static int AskQuestion(int countStep)
    {
        string[] questionBank = { "1. Сколько будет 2 плюс 2, умноженное на 2?", "2. Бревно нужно распилить на 10 частей. Сколько надо сделать распилов?",
            "3. На двух руках 10 пальцев. Сколько пальцев на 5 руках?", "4. Укол делают каждые полчаса. Сколько нужно минут для трех уколов?", "5. 5 свечей горело, 2 потухли. Сколько свечей осталось?" };
        string[] answerBank = { "6", "9", "25", "60", "2" };
        int[] bank = new int[questionBank.Length];
        for (int i = 0; i < bank.Length; i++)
        {
            bank[i] = i;
        }
        int countCorrectAnswer = 0;
        Random rand = new Random();
        while (countStep > 0)
        {
            int i = rand.Next(questionBank.Length);
            while (bank[i] == -1)
            {
                i = rand.Next(questionBank.Length);
            }
            bank[i] = -1;
            Console.WriteLine(questionBank[i]);
            string answer = Console.ReadLine();

            int number;
            if (!int.TryParse(answer, out number))
            {
                Console.WriteLine("Пожалуйста, введите число");
            }

            if (answer == answerBank[i])
            {
                countCorrectAnswer++;
            }
            countStep--;
        }
        return countCorrectAnswer;
    }

    static void GettingResults(int countCorrectAnswer, string name)
    {
        if (countCorrectAnswer == 5) Console.WriteLine(name + " - вы гений");
        else if (countCorrectAnswer == 4) Console.WriteLine(name + " - вы талант");
        else if (countCorrectAnswer == 3) Console.WriteLine(name + " - вы нормальный");
        else if (countCorrectAnswer == 2) Console.WriteLine(name + " - вы дурак");
        else if (countCorrectAnswer == 1) Console.WriteLine(name + " - вы кретин");
        else if (countCorrectAnswer == 0) Console.WriteLine(name + " - вы идиот");

    }

}