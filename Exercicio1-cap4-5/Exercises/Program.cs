using System.Globalization;
using System.Text.RegularExpressions;

namespace Exercises
{
	class Program
	{

		static int NumConta()
		{
			while (true)
			{
				string num = "";
				bool op = true;
				int numC = 0;

				try
				{
					Console.Write("Entre o número da conta: ");
#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
					num = Console.ReadLine().Trim();
#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.
					op = int.TryParse(num, out numC);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"O seguinte erro ocorreu: {ex.Message}");
					Console.WriteLine($"\nA opção digitada '{num}' não é válida!" +
								"\nPor favor digite um número válido.");
				}
				finally
				{
					switch (op)
					{
						case false:
							Console.WriteLine($"A opção digitada '{num}' não é válida!" +
								"\nPor favor digite um número válido.");
							break;
						default:
							numC = int.Parse(num);
							break;
					}
				}

				if (op)
				{
					return numC;
				}
			}
		}

		public static Boolean IsAlphaNumeric(string strToCheck)
		{
			Regex rg = new Regex("[0-9]");

			//if has Numeric char, return true, else return false.
			if (rg.IsMatch(strToCheck))
				return true;
			else
				return false;
		}

		static string TitularConta()
		{
			bool op = false;
			string str = "";

			while (true) {
				try
				{
					Console.Write("Entre o nome do titular da conta: ");
#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
					str = Console.ReadLine().Trim();
#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.
					op = IsAlphaNumeric(str);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"O seguinte erro ocorreu: {ex.Message}");
					Console.WriteLine($"\nA opção digitada '{str}' não é válida!" +
								"\nPor favor digite um nome de titular válido.");
				}
				finally
				{
					switch (op)
					{
						case false:
							break;
						default:
							Console.WriteLine($"\nA opção digitada '{str}' não é válida!" +
								"\nPor favor digite um nome de titular válido.");
							break;
					}
				}
				if (!op)
				{
					return str;
				}
			}
		}

		static char Operation()
		{
			while (true)
			{
				char op = 's';
				try
				{
					Console.Write("Haverá depósito inicial (s/n)? ");
					op = Console.ReadKey().KeyChar;
				
				}
				catch (Exception ex)
				{
					Console.WriteLine($"O seguinte erro ocorreu: {ex.Message}");
					Console.WriteLine($"\nA opção digitada '{op}' não é válida!" +
								"\nPor favor digite s ou n apenas.");
				}
				finally
				{
					switch (op)
					{
						case 's' or 'n' or 'S' or 'N':
							break;
						default:
							Console.WriteLine($"\nA opção digitada '{op}' não é válida!" +
								"\nPor favor digite s ou n apenas.");
							break;
					}
				}

				if (op is 's' or 'n')
				{
					return op;
				}
			}			
		}

		static double SaldoConta(int i)
		{
			while (true)
			{
				string num = "";
				bool op = true;
				double saldo = 0.00;

				try
				{
					switch (i)
					{
						case 1:
							Console.Write("\nEntre um valor para depósito: ");
							break;
						case 2:
							Console.Write("\nEntre um valor para saque: ");
							break;
						default:
							Console.Write("\nEntre o valor de depósito inicial: ");
							break;
					}
					

#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
					num = Console.ReadLine().Trim();
#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.
					op = double.TryParse(num, out saldo);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"O seguinte erro ocorreu: {ex.Message}");
					Console.WriteLine($"\nA opção digitada '{num}' não é válida!" +
								"\nPor favor digite um valor válido.");
				}
				finally
				{
					switch (op)
					{
						case false:
							Console.WriteLine($"A opção digitada '{num}' não é válida!" +
								"\nPor favor digite um valor válido.");
							break;
						default:
							saldo = double.Parse(num, CultureInfo.InvariantCulture); ;
							break;
					}
				}

				if (op)
				{
					return saldo;
				}
			}
		}

		static void Main(string[] args)
		{
			Contas conta1;

			int nConta;
			string titular;
			double saldo;

			char op;
			
			nConta = NumConta();
			titular = TitularConta();
			op = Operation();
			
			switch (op)
			{
				case 'n':
					conta1 = new Contas(nConta, titular);
					Console.WriteLine();
					break;
				default:
					saldo = SaldoConta(0);

					conta1 = new Contas(nConta, titular, saldo);
					break;
			}

			Console.WriteLine($"\nDados da conta: {conta1}");
			
			saldo = SaldoConta(1);
			conta1.Depositos(saldo);
			Console.WriteLine($"\nDados da conta: {conta1}");

			saldo = SaldoConta(2);
			conta1.Saques(saldo);
			Console.WriteLine($"\nDados da conta: {conta1}");

			Console.ReadLine();
		}
	} 
}
