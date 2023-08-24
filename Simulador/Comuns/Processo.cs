using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comuns
{
    public class Processo
    {
        public Processo() { }
        public Processo(int chegada, int tempoDeServico, int prioridade)
        {
            TempoChegada = chegada;
            TempoDeServico = tempoDeServico;
            Prioridade = prioridade;
        }

        public int TempoDeServico { get; set; }
        public int Prioridade { get; set; }
        public int TempoChegada { get; set; }
        public int TempoTermino { get; set; }
        public int TempoServicoRestante { get; set; }
        public bool IsDone { get => TempoServicoRestante == 0; }
    }
}
