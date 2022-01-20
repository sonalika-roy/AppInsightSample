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
    public class EditModel : PageModel
    {
        private PubsService _pubsService = null;

        [BindProperty]
        public Author Author { get; set; }

        [TempData]
        public string Message { get; set; }

        public SelectList StateList { get; set; }

        public EditModel(PubsService pubsService)
        {
            _pubsService = pubsService;
        }

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

            StateList = new SelectList(State.List, "Key", "Value", Author.State);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _pubsService.UpdateAuthor(Author);
            Message = "Changes saved successfully!";

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostDelete(string id)
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
