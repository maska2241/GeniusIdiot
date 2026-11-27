using System;
using System.Collections.Generic;
using System.IO;

public class MainClass
{
    public static void Main()
    {
        Console.WriteLine("Введите свое имя: ");
        string name = Console.ReadLine();
        string pathTest = "../../../data/test.txt";
        string pathResults = "../../../data/result.txt";
        File.AppendAllText(pathTest, "");
        while (true)
        {
            List<string> list = new List<string>;
            if (File.Exists(pathTest))
            {
                AddQuestion(pathTest);
            }
            File.ReadAllLines("")
            int countCorrectAnswer = AskQuestion(countStep);
            GettingResults(countCorrectAnswer, name);
            Console.WriteLine("Хотите сыграть ещё раз (Да / Нет):");
            if (Console.ReadLine() != "Да")
            {
                break;
            }

        }

        
    }

    static void AddQuestion(string path)
    {
        Console.WriteLine("Введите количество добавляемых вопросов: ");
        int countQuestions = int.Parse(Console.ReadLine());

        Console.WriteLine("Добавьте вопросы и правильные ответы на них (1 вопрос - 1 ответ): ");
        List<string> question = new List<string>();
        List<string> answers = new List<string>();

        for (int i = 0; i < countQuestions; i++)
        {
            string[] q = Console.ReadLine().Split();
            question.Add(q[0]);
            answers.Add(q[1]);
        }

        File.AppendAllText(path, Convert.ToString(countQuestions));
        File.AppendAllLines(path, question);
        File.AppendAllLines(path, answers);

    }
    static int AskQuestion(int countStep)
    {
        
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