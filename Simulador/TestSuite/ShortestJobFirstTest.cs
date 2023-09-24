namespace TestSuite
{
    public class ShortestJobFirstTest
    {
        IEnumerable<Processo> Processos { get; set; }
        Escalonador Escalonador { get; set; }

        public ShortestJobFirstTest()
        {
            Processos = GeradorProcessos.GeraProcessosPadroes();
            Escalonador = new ShortestJobFirst(new ReadyQueue(Processos)); 
            Escalonador.Executa();
        }

        [Fact]
        public void AllProcessDones() => Assert.True(Processos.All(p => p.IsDone));

        [Fact]
        public void RightConclusionTimes()
        {
            Assert.True(Processos.ElementAt(0).TempoTermino == 14);
            Assert.True(Processos.ElementAt(1).TempoTermino == 2);
            Assert.True(Processos.ElementAt(2).TempoTermino == 6);
            Assert.True(Processos.ElementAt(3).TempoTermino == 7);
            Assert.True(Processos.ElementAt(4).TempoTermino == 9);
        }
    }
}
