using Comuns;

namespace Simulador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var escalonadorFCFS = new FirstComeFirstServed(new ReadyQueue(GeradorProcessos.GeraProcessosPadroes()));
            var escalonadorSJF = new ShortestJobFirst(new ReadyQueue(GeradorProcessos.GeraProcessosPadroes()));

            var processosFCFS = escalonadorFCFS.Executa();
            var processosSJF = escalonadorSJF.Executa();

            Console.WriteLine($"FCFS ---- Tempo Execucao: {CalculoNegocio.TempoMedioExecucao(processosFCFS)} | Tempo de espera: {CalculoNegocio.TempoMedioEspera(processosFCFS)}");
            Console.WriteLine($"SJF ---- Tempo Execucao: {CalculoNegocio.TempoMedioExecucao(processosSJF)} | Tempo de espera: {CalculoNegocio.TempoMedioEspera(processosSJF)}");
        }
    }
}