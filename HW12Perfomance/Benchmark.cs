using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace HW12Perfomance
{
    [MinColumn]
    [MaxColumn]
    public class Benchmark
    {
         private HttpClient _clientCSharp;
            private HttpClient _clientFSharp;
        
            private const string FSharpUrl = "https://localhost:44348/calc";
            private const string CSharpUrl = "https://localhost:44314/calc";

            [GlobalSetup]
            public void GlobalSetUp()
            {
                _clientCSharp = new WebAppFactory<HW8_DI.Startup>().CreateDefaultClient();
                _clientFSharp = new WebAppFactory<HW6Giraffe.Startup>().CreateDefaultClient();
            }

            [Benchmark(Description = "f# 12+12")]
            public async Task PlusFSharp() 
                => await _clientFSharp.GetAsync(FSharpUrl + "?value1=12&value2=12&operation=sum");
        
            [Benchmark(Description = "c# 12+12")]
            public async Task PlusCSharp() 
                => await _clientCSharp.GetAsync(CSharpUrl + "?value1=12&value2=12&operation=sum");
            
            [Benchmark(Description = "f# 20-2")]
            public async Task MinusFSharp() 
                => await _clientFSharp.GetAsync(FSharpUrl + "?value1=20&value2=2&operation=minus");
        
            [Benchmark(Description = "c# 20-2")]
            public async Task MinusCSharp() 
                => await _clientCSharp.GetAsync(CSharpUrl + "?value1=20&value2=2&operation=minus");
        
            [Benchmark(Description = "f# 10*2")]
            public async Task MultiplicationFSharp() 
                => await _clientFSharp.GetAsync(FSharpUrl + "?value1=10&value2=2&operation=mult");
        
            [Benchmark(Description = "c# 10*2")]
            public async Task MultiplicationCSharp() 
                => await _clientCSharp.GetAsync(CSharpUrl + "?value1=10&value2=2&operation=mult");
            
            [Benchmark(Description = "f# 32/32")]
            public async Task DivisionFSharp() 
                => await _clientFSharp.GetAsync(FSharpUrl + "?value1=32&value2=32&operation=div");
        
            [Benchmark(Description = "c# 32/32")]
            public async Task DivisionCSharp() 
                => await _clientCSharp.GetAsync(CSharpUrl + "?value1=32&value2=32&operation=divide");
    }
}