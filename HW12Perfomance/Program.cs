using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;


namespace HW12Perfomance
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
}