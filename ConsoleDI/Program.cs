using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDI
{
    public class ConsoleMessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }


    public interface IMessageWriter
    {
        void Write(string message);
    }

    public class Salutation
    {
        private readonly IMessageWriter writer;
        public Salutation(IMessageWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            this.writer = writer;
        }
        public void Exclaim()
        {
            this.writer.Write("Hello DI!");
        }
     }

    class Program
    {

        static void Main(string[] args)
        {
            IMessageWriter writer = new ConsoleMessageWriter();
            var satul = new Salutation(writer);
            satul.Exclaim();
            Console.ReadLine();
        }
    }
}
