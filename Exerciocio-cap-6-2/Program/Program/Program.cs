using System.Globalization;
using System.Text.RegularExpressions;

namespace Program
{
	internal class Program
	{
		static int IdFuncionario(List<Employee> list)
		{
			string num = "";
			bool op = true;
			bool first = true;
			int numC = 0;

			while (true)
			{
				try
				{
					if (first)
						Console.Write("Entre o ID da(o) funcionária(o): ");
					else
						Console.Write("Entre com um ID que não esteja cadastrado no momento: ");

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

				if (!op)
				{
					Console.WriteLine($"A opção digitada '{num}' não é válida!" +
						"\nPor favor digite um número válido.");
				}
				else
				{
					if (list.Count > 0)
					{
						foreach (Employee emp in list)
						{
							if (numC == emp.Id)
							{
								first = false;
							}
							else
							{
								return numC;
							}
						}
					}
					else
					{
						return numC;
					}
				}
			}
		}

		static bool IsAlphaNumeric(string strToCheck)
		{
			Regex rg = new Regex("[0-9]");

			//if has Numeric char, return true, else return false.
			if (rg.IsMatch(strToCheck))
				return true;
			else
				return false;
		}

		static string NomeFuncionario()
		{
			bool op = false;
			string str = "";

			while (true)
			{
				try
				{
					Console.Write("Entre com o nome da(o) funcionário: ");
#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
					str = Console.ReadLine().Trim();
#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.
					op = IsAlphaNumeric(str);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"O seguinte erro ocorreu: {ex.Message}");
					Console.WriteLine($"\nA opção digitada '{str}' não é válida!" +
								"\nPor favor digite um nome válido.");
				}
				finally
				{
					switch (op)
					{
						case false:
							break;
						default:
							Console.WriteLine($"\nA opção digitada '{str}' não é válida!" +
								"\nPor favor digite um nome válido.");
							break;
					}
				}
				if (!op)
				{
					return str;
				}
			}
		}

		static decimal SalarioFuncionario()
		{
			string num = "";
			bool op = true;
			decimal saldo = 0.00M;

			while (true)
			{
				try
				{
					Console.Write("Entre com o valor de salário da(o) funcionária(o): ");
#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
					num = Console.ReadLine().Trim();
#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.
					op = decimal.TryParse(num, out saldo);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"O seguinte erro ocorreu: {ex.Message}");
					Console.WriteLine($"\nA opção digitada '{num}' não é válida!" +
								"\nPor favor digite um valor válido.");
				}

				if (!op)
				{
					Console.WriteLine($"A opção digitada '{num}' não é válida!" +
						"\nPor favor digite um valor válido.");
				}
				else
				{
					return saldo;
				}
			}
		}

		static void Main(string[] args)
		{
			/* declaração de variaveis locais */
			int id;
			string nome;
			decimal salario;

			/* declaração de classe e lista de classe */
			Employee? employee;
			List<Employee> employees = new();

			Console.Write("Quantos funcionários serão cadastrados? ");
			int n = int.Parse(Console.ReadLine().Trim());

			for (int i = 1; i <= n; i++)
			{
				Console.WriteLine($"\n#{i} Funcionária(o):");

				id = IdFuncionario(employees);
				nome = NomeFuncionario();
				salario = SalarioFuncionario();

				employee = new Employee(id, nome, salario);
				employees.Add(employee);
			}

			Console.Write("\nEntre com a Identificação da(o) funcionária(o) que terá um acréscimo salarial: ");
			int BuscaId = int.Parse(Console.ReadLine().Trim());
			employee = employees.Find(x => x.Id == BuscaId);

			Console.Write("Entre com a porcentagem de acréscimo salarial que a(o) funcionária(o) receberá: ");
			decimal porcent = decimal.Parse(Console.ReadLine().Trim(), CultureInfo.InvariantCulture);
			employee.AumentaSalario(porcent);

			Console.WriteLine();

			foreach (Employee emp in employees)
			{
				Console.WriteLine(emp);
			}

			Console.ReadLine();
		}
	}
}