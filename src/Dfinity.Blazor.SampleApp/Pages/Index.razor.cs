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

        public async Task WriteData()
        {
            await DfinityService.SetValue("time", DateTimeOffset.UtcNow.ToString());
        }
        public async Task GetData()
        {
            string value = await DfinityService.GetValue("time");
            Console.WriteLine("Value: " + value);
        }


        public async Task IsLoggedIn()
        {
            bool isLoggedIn = await DfinityService.IsLoggedIn();
            Console.WriteLine("Logged in: " + isLoggedIn);
        }

        public async Task Login()
        {
            await DfinityService.Login();
        }

        public async Task Logout()
        {
            await DfinityService.Logout();
        }


        public async Task WriteDataForUser()
        {
            await DfinityService.SetValueForUser("time", DateTimeOffset.UtcNow.ToString());
        }
        public async Task GetDataForUser()
        {
            var value = await DfinityService.GetValueForUser("time");
            Console.WriteLine("Uservalue: " + value);

        }


        public void Dispose()
        {
        }
    }
}
