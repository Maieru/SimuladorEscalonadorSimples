using Comuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador
{
    public class ShortestRemainingTimeFirst : Escalonador
    {
        public ShortestRemainingTimeFirst(ReadyQueue processos) : base(processos)
        {
        }

        protected override Processo RecuperaProximoProcesso() => ReadyQueue.OrderBy(p => p.TempoServicoRestante).FirstOrDefault();
    }
}
