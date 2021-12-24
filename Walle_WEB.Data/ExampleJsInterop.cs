using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Walle_WEB.Data
{
    public class ExampleJsInterop
    {
        public static ValueTask<string> Prompt(IJSRuntime jsRuntime, string message)
        {
            // Implemented in exampleJsInterop.js
            return jsRuntime.InvokeAsync<string>(
                "exampleJsFunctions.showPrompt",
                message);
        }
    }
}
