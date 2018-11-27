using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace InputSystem {
    class Program {
        public static BlockingCollection<ConsoleKeyInfo> bCollect;

        public static void Main(string[] args) {
            bCollect = new BlockingCollection<ConsoleKeyInfo>();
            Thread reader = new Thread(InputKey);
            Thread writer = new Thread(WriteKey);
            reader.Start();
            writer.Start();
            reader.Join();
            writer.Join();
        }

        public static void InputKey() {
            ConsoleKeyInfo key;

            do {
                key = Console.ReadKey(true);
                bCollect.Add(key);
            } while (key.Key != ConsoleKey.Escape);
        }

        public static void WriteKey() {
            ConsoleKeyInfo key;

            while ((key = bCollect.Take()).Key != ConsoleKey.Escape) {
                if (key.Key == ConsoleKey.W) {
                    Console.WriteLine("Cima");
                }
                else if (key.Key == ConsoleKey.A) {
                    Console.WriteLine("Esquerda");
                }
                else if (key.Key == ConsoleKey.S) {
                    Console.WriteLine("Baixo");
                }
                else if (key.Key == ConsoleKey.D) {
                    Console.WriteLine("Direita");
                }
            }
        }
    }
}
