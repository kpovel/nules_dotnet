namespace KeyEvent
{
    class Program
    {
        public delegate void KeyPressEvent();

        public static event KeyPressEvent? OnKeyPress;

        static void Main(string[] args)
        {
            OnKeyPress += DisplayFullName;

            Console.WriteLine("Press a key...");

            while (true)
            {
                var keyInfo = Console.ReadKey();

                if (Char.ToLower(keyInfo.KeyChar) == 'p')
                {
                    OnKeyPress?.Invoke();
                }
            }
        }

        static void DisplayFullName()
        {
            Console.WriteLine("\nPavlo");
        }
    }
}

