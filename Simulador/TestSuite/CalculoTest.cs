using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite
{
    public class CalculoTest
    {
        IEnumerable<Processo> Processos { get; set; }

        public CalculoTest()
        {
            Processos = GeradorProcessos.GeraProcessosPadroes();

            var instanteAtual = 0;
            foreach (var item in Processos)
                while (item.TempoServicoRestante > 0)
                    item.DiminuiTempoServicoRestante(instanteAtual++);

        }

        [Fact]
        public void ExecutionMeanTimeRight() => Assert.Equal(8, CalculoNegocio.TempoMedioExecucao(Processos));

        [Fact]
        public void WaitMeanTimeRight() => Assert.Equal(5.2, CalculoNegocio.TempoMedioEspera(Processos));
    }
}
