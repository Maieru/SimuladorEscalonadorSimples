using Comuns;
using Comuns.Escalonadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador
{
    public class FirstComeFirstServed : Escalonador
    {
        public FirstComeFirstServed(ReadyQueue processos) : base(processos)
        {
        }

        protected override Processo RecuperaProximoProcesso() => ReadyQueue.FirstOrDefault();
    }
}
