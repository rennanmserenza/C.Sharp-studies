using System.Globalization;

namespace Exercises
{
	internal class Contas
	{
		public int NumConta { get; private set; }
		public string Titular { get; private set; }
		public double Saldo { get; private set; }

		public Contas(int numConta, string titular)
		{
			NumConta = numConta;
			Titular = titular;
		}

		public Contas(int numConta, string titular, double depositoInicial) : this(numConta,titular)
		{
			Depositos(depositoInicial);
		}

		public override string ToString()
		{
			return $"\nConta {NumConta}, " +
				$"Titular: {Titular}, " +
				$"Saldo: ${Saldo.ToString("n", CultureInfo.InvariantCulture)}";
		}

		public void Depositos(double value)
		{
			Saldo += value;
		}

		public void Saques(double value)
		{
			Saldo -= value + 5.00;
		}
	}
}
