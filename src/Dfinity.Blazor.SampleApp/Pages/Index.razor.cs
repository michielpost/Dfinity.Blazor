using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfinity.Blazor.SampleApp.Pages
{
    public partial class Index : IDisposable
    {
        [Inject]
        public DfinityService DfinityService { get; set; } = default!;

        public async Task Test()
        {
            await DfinityService.Test();
        }

        public void Dispose()
        {
        }
    }
}
