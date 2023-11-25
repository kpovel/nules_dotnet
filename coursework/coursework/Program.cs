namespace coursework;

internal sealed class CountdownTimer(int seconds)
{
    public delegate void CountdownCompletedHandler();

    public event CountdownCompletedHandler CountdownCompleted = null!;

    public void Start()
    {
        Console.WriteLine("Countdown started...");
        while (seconds > 0)
        {
            Console.Write($"\rTime remaining: {seconds / 3600:D2}:{(seconds % 3600) / 60:D2}:{seconds % 60:D2}");
            Thread.Sleep(1000);
            seconds--;
        }

        Console.WriteLine("\rCountdown completed!             ");
        OnCountdownCompleted();
    }

    private void OnCountdownCompleted()
    {
        CountdownCompleted?.Invoke();
    }
}

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine(
            "You can use the following command in the console by typing: " +
            "\n - 't hr-min-sec' to start a timer " +
            "\n - 'q' to quit the program"
        );

        while (true)
        {
            Console.Write("Enter command: ");
            string input = Console.ReadLine()!;

            if (input == "q")
            {
                break;
            }

            if (input.Trim() == "t")
            {
                Console.WriteLine(
                    "Please enter a time in the format hr-min-sec (e.g. 1-30-0 for 1 hour 30 minutes 0 seconds)"
                );
            }
            else if (input.StartsWith("t "))
            {
                string[] timeParts = input.Substring(2).Split('-');
                int hours = int.Parse(timeParts[0]);
                int minutes = int.Parse(timeParts[1]);
                int seconds = int.Parse(timeParts[2]);

                int totalSeconds = hours * 3600 + minutes * 60 + seconds;
                CountdownTimer timer = new CountdownTimer(totalSeconds);

                timer.Start();
            }
            else
            {
                Console.WriteLine("Unknown command!");
            }
        }
    }
}
