namespace NumberAnalyzer;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Welcome to the Number Analyzer!");
		Console.WriteLine("Please enter your name:");

		// get name
		var name = Console.ReadLine() ?? "";

		// capitalize name
		if (name.Length != 0)
			name = char.ToUpper(name[0]) + name[1..];

		// welcome
		Console.WriteLine($"Welcome {name}!");

		do // main loop
		{
			// get a number
			int num;
			Console.WriteLine("Please enter a number between 1 and 100 (inclusive).");
			while (!int.TryParse(Console.ReadLine(), out num) || num is < 1 or > 100)
				Console.WriteLine($"Please enter a valid number {name}.");

			bool isOdd = (num & 1) != 0;
			string evenodd = isOdd ? "odd" : "even";

			// set range description
			string description;
			if (isOdd)
			{
				// odd
				description = num < 60 ? "less than 60" : "greater than 60";
			}
			else
			{
				// even
				description = num switch
				{
					< 25 => "less than 25",
					<= 60 => "between 25 and 60",
					_ => "greater than 60"
				};
			}

			// print information
			Console.WriteLine($"{name}'s number is {evenodd} and {description}.");
			Console.WriteLine();

		} 
		while (PromptYesNo(true, $"Would you like to continue, {name}? Y/N"));

		// goodbye
		Console.WriteLine($"Goodbye {name}!");
		Console.WriteLine("Press any key to exit...");
		Console.ReadKey();
	}

	static bool PromptYesNo(bool allowEscape, string message)
	{
		Console.WriteLine(message);

		while (true)
		{
			// get keystroke
			char key = Console.ReadKey().KeyChar;

			// deletes echoed keystroke from output
			Console.Write("\b\\\b");

			// process keystroke
			switch (key)
			{
				// yes
				case 'y':
				case 'Y':
					return true;

				// no
				case 'n':
				case 'N':
					return false;

				// escape key
				case '\x1b':
					if (allowEscape)
						return false;
				break;
			}
		}
	}
}
