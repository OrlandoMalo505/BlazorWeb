using Microsoft.JSInterop;

namespace BlazorWeb_Server.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async Task<ValueTask> ToastrSuccess(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
            return ValueTask.CompletedTask;
        }

        public static async Task<ValueTask> ToastrFailed(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
            return ValueTask.CompletedTask;

        }
    }
}
