using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PubsRepository.Models;
using PubsRepository.Services;
using System.Collections.Generic;

namespace PubsRazorPages.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private ILogger _logger = null;
        private PubsService _pubsService = null;

        public List<Author> Authors { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(ILogger<IndexModel> logger, PubsService pubsService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _pubsService = pubsService;
            RequestTelemetry requestTelemetry = httpContextAccessor.HttpContext.Features.Get<RequestTelemetry>();
            if (httpContextAccessor.HttpContext.Session != null &&
                requestTelemetry != null && string.IsNullOrEmpty(requestTelemetry.Context.User.Id))
            {
                requestTelemetry.Context.User.Id = httpContextAccessor.HttpContext.Session.Id;
            }

        }
        public IActionResult OnGet()
        {
            _logger.LogInformation("Author Index: Retrieving Authors...");
            this.Authors = _pubsService.ListAuthors();
            return Page();
        }
    }
}