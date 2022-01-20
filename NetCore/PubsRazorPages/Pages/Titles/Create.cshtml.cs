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
using System;
using System.Collections.Generic;

namespace PubsRazorPages.Pages.Titles
{
    public class CreateModel : PageModel
    {
        private PubsService _pubsService = null;

        public CreateModel(PubsService pubsService)
        {
            _pubsService = pubsService;
        }

        public IActionResult OnGet()
        {
            List<Publisher> publishers = _pubsService.ListPublishers();
            publishers.Insert(0, new Publisher() { PublisherID = "", Name = "Choose a publisher" });
            PublisherList = new SelectList(publishers, "PublisherID", "Name", string.Empty);
            Title = new Title();
            Title.PublishDate = DateTime.Today;
            return Page();
        }

        [BindProperty]
        public Title Title { get; set; }

        [TempData]
        public string Message { get; set; }

        public SelectList PublisherList { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Construct authors collection
            if (Title.Authors == null)
            {
                Title.Authors = new List<TitleAuthor>();
            }
            else
            {
                Title.Authors.Clear();
            }
            List<Author> authors = _pubsService.ListAuthors();
            foreach (Author a in authors)
            {
                if (!string.IsNullOrEmpty(Request.Form[string.Format("author-{0}", a.AuthorID)]))
                {
                    Title.Authors.Add(new TitleAuthor() { AuthorID = a.AuthorID, TitleID = Title.TitleID });
                }
            }

            _pubsService.CreateTitle(Title);
            Message = "Title created successfully!";

            return RedirectToPage("./Index");
        }
    }
}