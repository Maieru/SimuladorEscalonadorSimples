using Comuns;

namespace Simulador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jobQueue = new ReadyQueue(GeradorProcessos.GeraProcessosPadroes());

            foreach(var job in jobQueue)
            {

            }

            Console.WriteLine("Hello, World!");
        }
    }
}