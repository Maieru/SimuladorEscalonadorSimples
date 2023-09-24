using Comuns;
using Comuns.Escalonadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador
{
    public class RoundRobin : Escalonador
    {
        private Queue<Processo> Queue = new Queue<Processo>();
        private int Quantum { get; set; } = 2;
        private int QuantumCounter { get; set; } = 0;
        private bool IsQuantumChange { get => QuantumCounter >= Quantum; }

        public RoundRobin(ReadyQueue processos) : base(processos)
        {
        }

        public RoundRobin(ReadyQueue processos, int quantum) : base(processos)
        {
            Quantum = quantum;
        }

        protected override Processo RecuperaProximoProcesso()
        {
            var lista = ReadyQueue.ToList();
            QuantumCounter++;
            AjustaFila(lista);

            if (ProcessoAtual != null)
            {
                if (!IsQuantumChange && ProcessoAtual.TempoServicoRestante > 0)
                    return ProcessoAtual;

                var processo = Queue.Dequeue();

                if (!ProcessoAtual.IsDone && ProcessoAtual.Id == Queue.First().Id)
                    Queue.Enqueue(processo);

            }

            QuantumCounter = 0;
            return Queue.First();
        }

        public void AjustaFila(List<Processo> ReadyQueue)
        {
            foreach (var processo in ReadyQueue)
                if (!Queue.Any(p => p.Id == processo.Id))
                    Queue.Enqueue(processo);
        }
    }
}
