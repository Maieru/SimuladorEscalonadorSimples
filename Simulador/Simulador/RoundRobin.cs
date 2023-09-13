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
            var lista = ReadyQueue.AsEnumerable().ToList();

            if (ProcessoAtual != null && !ProcessoAtual.IsDone)
            {
                if (!IsQuantumChange)
                    return ProcessoAtual;

                lista.Add(ProcessoAtual);
            }

            var processo = lista.First();
            lista.Remove(processo);

            ReadyQueue = new ReadyQueue(lista.AsEnumerable());

            return processo;
        }
    }
}
