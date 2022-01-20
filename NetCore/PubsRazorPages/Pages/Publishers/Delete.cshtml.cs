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

namespace PubsRazorPages.Pages.Publishers
{
    public class DeleteModel : PageModel
    {
        private PubsService _pubsService = null;
        private readonly PubsRepository.Context.PubsContext _context;

        [BindProperty]
        public Publisher Publisher { get; set; }

        [TempData]
        public string Message { get; set; }

        public DeleteModel(PubsService pubsService)
        {
            _pubsService = pubsService;
        }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publisher = _pubsService.GetPublisher(id); ;

            if (Publisher == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _pubsService.DeletePublisher(id);
            Message = "Publisher deleted successfully!";

            return RedirectToPage("./Index");
        }
    }
}
