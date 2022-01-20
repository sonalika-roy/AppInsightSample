//===============================================================================
// Microsoft FastTrack for Azure
// Application Insights Examples
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PubsRepository.Models;
using PubsRepository.Services;
using System.Collections.Generic;

namespace PubsRazorPages.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private TelemetryClient _telemetryClient = null;
        private PubsService _pubsService = null;

        public IList<Publisher> Publishers { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(TelemetryClient telemetryClient, PubsService pubsService)
        {
            _telemetryClient = telemetryClient;
            _pubsService = pubsService;
        }

        public IActionResult OnGet()
        {
            _telemetryClient.TrackTrace("Publisher Index: Retrieving Publishers...");
            this.Publishers = _pubsService.ListPublishers();
            return Page();
        }
    }
}
