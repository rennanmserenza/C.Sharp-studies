namespace Program
{
	internal class Employee
	{
		public int Id { get; private set; }
		public string? Nome { get; private set; }
		public decimal Salario { get; private set; }

		public Employee()
		{

		}
		public Employee(int id, string nome, decimal salario)
		{
			Id = id;
			Nome = nome;
			Salario = salario;
		}

		public override string ToString()
		{
			return $"Nº de identificação: {Id}, " +
				$"Nome da(o) funcionária(o): {Nome}, " +
				$"Salário da(o) funcionária(o): ${Salario:n}";
		}

		public void AumentaSalario(decimal porcentagem)
		{
			Salario += (Salario * (porcentagem / 100));
		}
	}
}
