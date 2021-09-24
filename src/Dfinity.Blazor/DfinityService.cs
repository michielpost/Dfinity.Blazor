using Microsoft.JSInterop;
using System;
using System.Linq;
using System.Numerics;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dfinity.Blazor
{
    // This class provides JavaScript functionality for Dfinity wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    public class DfinityService : IAsyncDisposable
    {
        //private readonly Lazy<Task<IJSObjectReference>> moduleTask;
        private readonly IJSRuntime jsRuntime;

        public static event Func<bool, Task>? IsLoggedInEvent;
        //public static event Func<(int, Chain), Task>? NetworkChangedEvent;
        //public static event Func<Task>? ConnectEvent;
        //public static event Func<Task>? DisconnectEvent;

        public DfinityService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
            //moduleTask = new(() => LoadScripts(jsRuntime).AsTask());
        }

        public ValueTask<IJSObjectReference> LoadScripts(IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Dfinity.Blazor/index.js");
        }

        public async ValueTask Test()
        {
            try
            {
                await jsRuntime.InvokeVoidAsync("EntryPoint.test");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ValueTask SetValue(string key, string value)
        {
            return jsRuntime.InvokeVoidAsync("EntryPoint.setValue", key, value);
        }

        public async ValueTask<string?> GetValue(string key)
        {
            var result = await jsRuntime.InvokeAsync<string[]>("EntryPoint.getValue", key);
            return result.FirstOrDefault();
        }

        public ValueTask SetValueForUser(string key, string value)
        {
            return jsRuntime.InvokeVoidAsync("EntryPoint.setValueForUser", key, value);
        }

        public async ValueTask<string?> GetValueForUser(string key)
        {
            var result = await jsRuntime.InvokeAsync<string[]>("EntryPoint.getValueForUser", key);
            return result.FirstOrDefault();
        }


        public ValueTask<bool> IsLoggedIn()
        {
            return jsRuntime.InvokeAsync<bool>("EntryPoint.isLoggedIn");
        }

        public ValueTask Login()
        {
            return jsRuntime.InvokeVoidAsync("EntryPoint.login");
        }

        public ValueTask Logout()
        {
            return jsRuntime.InvokeVoidAsync("EntryPoint.logout");
        }

        //public async ValueTask<bool> HasMetaMask()
        //{
        //    var module = await moduleTask.Value;
        //    try
        //    {
        //        return await module.InvokeAsync<bool>("hasMetaMask");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public async ValueTask<bool> IsSiteConnected()
        //{
        //    var module = await moduleTask.Value;
        //    try
        //    {
        //        return await module.InvokeAsync<bool>("isSiteConnected");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public async ValueTask ListenToEvents()
        //{
        //    var module = await moduleTask.Value;
        //    try
        //    {
        //        await module.InvokeVoidAsync("listenToChangeEvents");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public async ValueTask<string> GetSelectedAddress()
        //{
        //    var module = await moduleTask.Value;
        //    try
        //    {
        //        return await module.InvokeAsync<string>("getSelectedAddress", null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}



        //[JSInvokable()]
        //public static async Task IsLoggedIn()
        //{
        //    if (IsLoggedInEvent != null)
        //    {
        //        await IsLoggedInEvent.Invoke(true);
        //    }
        //}

        public async ValueTask DisposeAsync()
        {
            //if (moduleTask.IsValueCreated)
            //{
            //    var module = await moduleTask.Value;
            //    await module.DisposeAsync();
            //}
        }

    }
}
