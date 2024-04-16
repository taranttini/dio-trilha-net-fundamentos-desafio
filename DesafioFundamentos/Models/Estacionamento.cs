namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            var placa = ObterPlaca();
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Veículo já cadastrado.");
            }
            else
            {
                Console.WriteLine("Veículo cadastrado.");
                veiculos.Add(placa);
            }
        }

        private string ObterPlaca()
        {
            var placaVeiculo = Console.ReadLine();
            return placaVeiculo.ToUpper().Trim();
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = ObterPlaca();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horasPermanencia = 0;
                bool tempoValido = false;
                do
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    var quantidadeHorasPermanencia = Console.ReadLine();
                    tempoValido = int.TryParse(quantidadeHorasPermanencia, out horasPermanencia);

                    if (!tempoValido || horasPermanencia <= 0)
                    {
                        Console.WriteLine("Permanência inválida, digite um valor numérico do tipo inteiro maior que 0");
                    }
                }
                while (!tempoValido || horasPermanencia <= 0m);

                decimal valorTotal = precoInicial + precoPorHora * horasPermanencia;

                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"{veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
