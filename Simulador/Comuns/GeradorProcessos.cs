using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comuns
{
    public static class GeradorProcessos
    {
        public static IEnumerable<Processo> GeraProcessosPadroes()
        {
            return new List<Processo>() { new Processo(1, 0, 5, 2), new Processo(2, 0, 2, 3), new Processo(3, 1, 4, 1), new Processo(4, 3, 1, 4), new Processo(5,5, 2, 5) };
        }

        public static IEnumerable<Processo> GeraProcessosAleatorios(int seed) => throw new NotImplementedException();
    }
}
