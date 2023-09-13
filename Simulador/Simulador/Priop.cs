using Comuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador
{
    internal class Priop : Escalonador
    {
        public Priop(ReadyQueue processos) : base(processos)
        {
        }

        protected override Processo RecuperaProximoProcesso() => ReadyQueue.OrderBy(p => p.Prioridade).Last();

    }
}
