namespace TestSuite
{
    public class RoundRobinTest
    {
        IEnumerable<Processo> Processos { get; set; }
        Escalonador Escalonador { get; set; }

        public RoundRobinTest()
        {
            Processos = GeradorProcessos.GeraProcessosPadroes();
            Escalonador = new RoundRobin(new ReadyQueue(Processos)); 
            Escalonador.Executa();
        }

        [Fact]
        public void AllProcessDones() => Assert.True(Processos.All(p => p.IsDone));

        [Fact]
        public void RightConclusionTimes()
        {
            Assert.True(Processos.ElementAt(0).TempoTermino == 14);
            Assert.True(Processos.ElementAt(1).TempoTermino == 4);
            Assert.True(Processos.ElementAt(2).TempoTermino == 13);
            Assert.True(Processos.ElementAt(3).TempoTermino == 9);
            Assert.True(Processos.ElementAt(4).TempoTermino == 11);
        }
    }
}
