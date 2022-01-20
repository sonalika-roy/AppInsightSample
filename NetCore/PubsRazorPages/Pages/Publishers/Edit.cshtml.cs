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

namespace PubsRazorPages.Pages.Publishers
{
    public class EditModel : PageModel
    {
        private PubsService _pubsService = null;
        private readonly PubsRepository.Context.PubsContext _context;

        public EditModel(PubsService pubsService)
        {
            _pubsService = pubsService;
        }

        [BindProperty]
        public Publisher Publisher { get; set; }

        [TempData]
        public string Message { get; set; }

        public SelectList StateList { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publisher = _pubsService.GetPublisher(id);

            if (Publisher == null)
            {
                return NotFound();
            }

            StateList = new SelectList(State.List, "Key", "Value", Publisher.State);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _pubsService.UpdatePublisher(Publisher);
            Message = "Changed saved successfully!";

            return RedirectToPage("./Index");
        }
    }
}
