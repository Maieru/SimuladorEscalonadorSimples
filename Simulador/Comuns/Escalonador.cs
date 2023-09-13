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
        protected Processo ProcessoAtual { get; set; }

        public IEnumerable<Processo> Executa()
        {
            while (ReadyQueue.Any())
            {
                ProcessoAtual = RecuperaProximoProcesso();
                ProcessoAtual.DiminuiTempoServicoRestante(InstanteAtual);
                ReadyQueue.IncrementaProgramCounter();
                InstanteAtual++;
            }

            return ReadyQueue.GetDoneProcess();
        }
        protected abstract Processo RecuperaProximoProcesso();
    }
}
