namespace TestSuite
{
    public class FirstComeFirstServerdTest
    {
        IEnumerable<Processo> Processos { get; set; }
        Escalonador Escalonador { get; set; }

        public FirstComeFirstServerdTest()
        {
            Processos = GeradorProcessos.GeraProcessosPadroes();
            Escalonador = new FirstComeFirstServed(new ReadyQueue(Processos)); 
            Escalonador.Executa();
        }

        [Fact]
        public void AllProcessDones() => Assert.True(Processos.All(p => p.IsDone));

        [Fact]
        public void RightConclusionTimes()
        {
            Assert.True(Processos.ElementAt(0).TempoTermino == 5);
            Assert.True(Processos.ElementAt(1).TempoTermino == 7);
            Assert.True(Processos.ElementAt(2).TempoTermino == 11);
            Assert.True(Processos.ElementAt(3).TempoTermino == 12);
            Assert.True(Processos.ElementAt(4).TempoTermino == 14);
        }
    }
}
