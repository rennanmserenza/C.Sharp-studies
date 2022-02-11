namespace Exercise
{
	class Program
	{
		static void Main(string[] args)
		{
			AluguelQuartos[] quartos = new AluguelQuartos[10];

			Console.WriteLine("Possuímos um total de 10 quartos numerados de 0 a 9!");
			Console.Write("Quantos quartos serão locados? ");
			int? n = int.Parse(Console.ReadLine().Trim());

			for (int i = 1; i <= n; i++)
			{
				Console.WriteLine($"\nLocação #{i}:");
				Console.Write("Nome: ");
				string nome = Console.ReadLine().Trim();
				Console.Write("E-mail: ");
				string email = Console.ReadLine().Trim();
				Console.Write("Quarto: ");
				int quarto = int.Parse(Console.ReadLine().Trim());

				for (int j = 0; j < quartos.Length; j++)
				{
					if (j == quarto)
					{
						quartos[j] = new AluguelQuartos (nome, email);
						break;
					}
				}

			}

			Console.WriteLine("\nQuartos locados!\n");

			for (int i = 0; i < quartos.Length; i++)
			{
				if (quartos[i] != null)
				{
					Console.WriteLine($"{i}: {quartos[i].Nome}, {quartos[i].Email}");
				}
			}

			Console.ReadLine();

		}
	}
}
