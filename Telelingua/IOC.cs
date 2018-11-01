using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telelingua.API.Business;

namespace Telelingua.API
{
    public static class IOC
    {
        public static IServiceCollection ConfigureIOC(this IServiceCollection services) 
            => services
                .AddTransient<IReadFiles, ReadFiles>()
                .AddTransient<IReadFileInfo, ReadFileInfo>()
                .AddTransient<IDumpFile, DumpFile>()
            ;
    }
}
