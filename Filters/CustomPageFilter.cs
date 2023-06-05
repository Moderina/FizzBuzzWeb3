using FizzBuzzWeb.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace FizzBuzzWeb.Filters
{
    public class CustomPageFilter : IAsyncPageFilter
    {
        private readonly IBrowserService _browserService;
        public CustomPageFilter(IBrowserService browser)
        {
            _browserService = browser;
        }
        public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            await Task.CompletedTask;
        }
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            var useragent = context.HttpContext.Request.Headers;
            var builder = new StringBuilder(Environment.NewLine);
            foreach (var header in useragent)
            {
                builder.AppendLine($"{header.Key}: {header.Value}");
            }
            var headersDump = builder.ToString();

            var result = await _browserService.GetName(headersDump);
            if (result != "") context.HttpContext.Response.Redirect(result);

            await next.Invoke();
        }
    }
}
