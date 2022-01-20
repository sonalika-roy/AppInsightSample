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
using Microsoft.AspNetCore.Mvc.Rendering;
using PubsRepository.Models;
using PubsRepository.Services;

namespace PubsRazorPages.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private PubsService _pubsService = null;

        [BindProperty]
        public Author Author { get; set; }

        [TempData]
        public string Message { get; set; }

        public SelectList StateList { get; set; }

        public CreateModel(PubsService pubsService)
        {
            _pubsService = pubsService;
        }

        public IActionResult OnGet()
        {
            StateList = new SelectList(State.List, "Key", "Value", string.Empty);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _pubsService.CreateAuthor(Author);
            Message = "Author created successfully!";

            return RedirectToPage("./Index");
        }
    }
}