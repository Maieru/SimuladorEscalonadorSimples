using Comuns;
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
        private bool IsQuantumChange { get => InstanteAtual % Quantum == 0; } 

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
            AjustaFila(lista);

            if (ProcessoAtual != null)
            {
                if (!IsQuantumChange && ProcessoAtual.TempoServicoRestante > 0)
                    return ProcessoAtual;

                if (!ProcessoAtual.IsDone && ProcessoAtual.Id == Queue.First().Id)
                {
                    var processo = Queue.Dequeue();
                    Queue.Enqueue(processo);
                }
                else
                {
                    Queue.Dequeue();
                }
            }

            return Queue.First();
        }

        public void AjustaFila(List<Processo> ReadyQueue)
        {
            foreach (var processo in ReadyQueue)
            {
                if (!Queue.Any(p => p.Id == processo.Id))
                {
                    Queue.Enqueue(processo);
                }
            }
        }
    }
}
