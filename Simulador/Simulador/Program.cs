using Comuns;

namespace Simulador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listaProcessos = GeradorProcessos.GeraProcessosPadroes();
            var escalonadorFCFS = new FirstComeFirstServed(new ReadyQueue(listaProcessos));
            escalonadorFCFS.Executa();
        }
    }
}