using Comuns;

namespace Simulador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var escalonadorFCFS = new FirstComeFirstServed(new ReadyQueue(GeradorProcessos.GeraProcessosPadroes()));
            var escalonadorSJF = new ShortestJobFirst(new ReadyQueue(GeradorProcessos.GeraProcessosPadroes()));
            var escalonadorSRTF = new ShortestRemainingTimeFirst(new ReadyQueue(GeradorProcessos.GeraProcessosPadroes()));
            var escalonadorPRIOC = new Prioc(new ReadyQueue(GeradorProcessos.GeraProcessosPadroes()));
            var escalonadorPRIOP = new Priop(new ReadyQueue(GeradorProcessos.GeraProcessosPadroes()));

            var processosFCFS = escalonadorFCFS.Executa();
            var processosSJF = escalonadorSJF.Executa();
            var processosSRTF = escalonadorSRTF.Executa();
            var processosPRIOC = escalonadorPRIOC.Executa();
            var processosPRIOP = escalonadorPRIOP.Executa();

            Console.WriteLine($"FCFS ---- Tempo Execucao: {CalculoNegocio.TempoMedioExecucao(processosFCFS)} | Tempo de espera: {CalculoNegocio.TempoMedioEspera(processosFCFS)}");
            Console.WriteLine($"SJF ---- Tempo Execucao: {CalculoNegocio.TempoMedioExecucao(processosSJF)} | Tempo de espera: {CalculoNegocio.TempoMedioEspera(processosSJF)}");
            Console.WriteLine($"SRTF ---- Tempo Execucao: {CalculoNegocio.TempoMedioExecucao(processosSRTF)} | Tempo de espera: {CalculoNegocio.TempoMedioEspera(processosSRTF)}");
            Console.WriteLine($"PRIOC ---- Tempo Execucao: {CalculoNegocio.TempoMedioExecucao(processosPRIOC)} | Tempo de espera: {CalculoNegocio.TempoMedioEspera(processosPRIOC)}");
            Console.WriteLine($"PRIOP ---- Tempo Execucao: {CalculoNegocio.TempoMedioExecucao(processosPRIOP)} | Tempo de espera: {CalculoNegocio.TempoMedioEspera(processosPRIOP)}");

            Console.ReadLine();
        }
    }
}