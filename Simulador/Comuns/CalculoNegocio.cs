using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comuns
{
    public static class CalculoNegocio
    {
        public static double TempoMedioExecucao(IEnumerable<Processo> processos)
        {
            double somatoriaTempos = 0;

            foreach (var processo in processos)
                somatoriaTempos += processo.TempoTermino - processo.TempoChegada;

            return somatoriaTempos / processos.Count();
        }

        public static double TempoMedioEspera(IEnumerable<Processo> processos)
        {
            double somatoriaTemposEspera = 0;

            foreach (var processo in processos)
                somatoriaTemposEspera += processo.TempoTermino - processo.TempoChegada - processo.TempoDeServico;

            return somatoriaTemposEspera / processos.Count();
        }
    }
}
