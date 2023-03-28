namespace taxes
{
    internal class Program
    {
        public static void Main()
        {
            Final();
        }

        public static void Final()
        {
            double[] answers = Questionare();
            double item = Itemized(answers);
            double income = answers[5];
            int percentof;
            Console.Clear();
            switch (answers[0])
            {
                case 0:
                    percentof = 10;
                    break;

                default:
                    percentof = 20;
                    break;
            }
            switch (answers[0])
            {
                case 0:
                    income = item > 13850 ? income - item : income - 13850;

                    int[,] brackets =
                    {
                        { 11000, 12 },
                        { 44725, 22 },
                        { 95375, 24 },
                        { 182100, 32 },
                        { 231250, 35 },
                        { 578125, 37 }
                    };
                    for (int i = 0; i < 6; i++)
                    {
                        int po = percentof;
                        percentof = income >= brackets[i, 0] && income > 11000 ? brackets[i, 1] : percentof;
                        switch (po == percentof)
                        {
                            case true: break;
                        }
                    }
                    break;

                default:
                    income = item > 27700 ? income - item : income - 27700;
                    int[,] bracketsMarried =
                    {
                        { 22000, 12 },
                        { 89450, 22 },
                        { 190750, 24 },
                        { 364200, 32 },
                        { 462500, 35 },
                        { 693750, 37 }
                    };
                    for (int i = 0; i < 6; i++)
                    {
                        int po = percentof;
                        percentof = income >= bracketsMarried[i, 0] && income > 22000 ? bracketsMarried[i, 1] : percentof;
                        switch (po == percentof)
                        {
                            case true: break;
                        }
                    }
                    break;
            }
            double percent = (double)percentof / 100d;
            double total = income * percent;
            Console.WriteLine($"You owe {total} at {percentof}%.");
        }

        public static double Itemized(double[] inp)
        {
            double ans = (float)inp[1] * 0.075;
            int amount = inp[0] == 0 ? 2500 : 5000;
            switch (inp[5] < (inp[0] == 0 ? 75000 : 155000))
            {
                case true:
                    ans += inp[2];
                    ans += inp[3] < amount ? inp[3] : amount;
                    break;
            }
            ans += inp[5] < 239230 && inp[4] < 15950 ? inp[4] : 0;
            return ans;
        }

        public static double[] Questionare()
        {
            double[] answers = new double[5];
            Console.WriteLine("When you type a number in this entire program, do not add '$' before or any commas in the middle.\n");
            Console.WriteLine("Are you filing on your own or with your spouse? (0 = alone,1 = married)");
            answers[0] = int.Parse(Console.ReadLine());
            Console.WriteLine("Do you have any medical expenses? (yes enter amount; no type 0)");
            answers[1] = int.Parse(Console.ReadLine());
            Console.WriteLine("Do you have any un-compensated damages from federal disasters? (yes enter amount; no type 0)");
            answers[2] = int.Parse(Console.ReadLine());
            Console.WriteLine("Do you have any student loan debt? (yes type amount; no type 0)");
            answers[3] = int.Parse(Console.ReadLine());
            Console.WriteLine("Did you adopt a child this year? (if yes type the amount of all expenses you had to pay; no type 0)");
            answers[4] = int.Parse(Console.ReadLine());
            Console.WriteLine("How much do you make? (type amount)");
            answers[5] = int.Parse(Console.ReadLine());
            return (answers);
        }
    }
}