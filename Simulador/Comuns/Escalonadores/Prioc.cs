using Comuns;
using Comuns.Escalonadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador
{
    public class Prioc : Escalonador
    {
        public Prioc(ReadyQueue processos) : base(processos)
        {
        }

        protected override Processo RecuperaProximoProcesso()
        {
            if (ProcessoAtual != null && !ProcessoAtual.IsDone)
                return ProcessoAtual;

            return ReadyQueue.OrderBy(p => p.Prioridade).Last();
        }
    }
}
