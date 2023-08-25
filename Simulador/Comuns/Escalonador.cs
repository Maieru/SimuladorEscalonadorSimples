using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comuns
{
    public abstract class Escalonador
    {
        protected ReadyQueue ReadyQueue { get; set; }
        protected int InstanteAtual { get; set; }
        public Escalonador(ReadyQueue processos) { ReadyQueue = processos; }

        public void Executa()
        {
            while (ReadyQueue.Any())
            {
                var proximoProcesso = RecuperaProximoProcesso();
                proximoProcesso.DiminuiTempoServicoRestante(InstanteAtual);
                ReadyQueue.IncrementaProgramCounter();
                InstanteAtual++;
            }
        }
        protected abstract Processo RecuperaProximoProcesso();
    }
}
