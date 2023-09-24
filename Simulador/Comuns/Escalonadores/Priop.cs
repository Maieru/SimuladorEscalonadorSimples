using Comuns;
using Comuns.Escalonadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador
{
    public class Priop : Escalonador
    {
        public Priop(ReadyQueue processos) : base(processos)
        {
        }

        protected override Processo RecuperaProximoProcesso() => ReadyQueue.OrderBy(p => p.Prioridade).Last();

    }
}
