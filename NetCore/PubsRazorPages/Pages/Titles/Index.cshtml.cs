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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PubsRepository.Models;
using PubsRepository.Services;
using System.Collections.Generic;

namespace PubsRazorPages.Pages.Titles
{
    public class IndexModel : PageModel
    {
        private PubsService _pubsService = null;

        public IList<Title> Titles { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(PubsService pubsService)
        {
            _pubsService = pubsService;
        }

        public IActionResult OnGet()
        {
            //List<TitleView> titleViews = _pubsService.ListTitleViews();
            Titles = _pubsService.ListTitles();
            return Page();
        }
    }
}
