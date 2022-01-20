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

namespace PubsRazorPages.Pages.Authors
{
    public class DeleteModel : PageModel
    {
        private PubsService _pubsService = null;

        public DeleteModel(PubsService pubsService)
        {
            _pubsService = pubsService;
        }

        [BindProperty]
        public Author Author { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = _pubsService.GetAuthor(id);

            if (Author == null)
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

            _pubsService.DeleteAuthor(id);
            Message = "Author deleted successfully!";

            return RedirectToPage("./Index");
        }
    }
}
