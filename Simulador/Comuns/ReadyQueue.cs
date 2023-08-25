using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comuns
{
    public class ReadyQueue : IEnumerable<Processo>
    {
        public ReadyQueue(IEnumerable<Processo> jobs) { JobsQueue = jobs; }

        private int ProgramCounter { get; set; }
        private IEnumerable<Processo> JobsQueue { get; set; }
        private IEnumerable<Processo> WaitingQueue { get => JobsQueue.Where(processo => ProgramCounter >= processo.TempoChegada && !processo.IsDone); }

        public void IncrementaProgramCounter() => ProgramCounter++;

        public IEnumerator<Processo> GetEnumerator() => WaitingQueue.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => WaitingQueue.GetEnumerator();
    }
}
