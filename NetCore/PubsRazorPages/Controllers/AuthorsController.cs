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
using PubsRepository.Models;
using PubsRepository.Services;
using System.Collections.Generic;

namespace PubsRazorPages.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private PubsService _pubsService = null;

        public AuthorsController(PubsService pubsService)
        {
            _pubsService = pubsService;
        }

        // GET: api/authors
        [HttpGet]
        public List<Author> Get()
        {
            // List authors
            List<Author> model = _pubsService.ListAuthors();

            // Remove circular references - JSON serializer cannot handle them
            foreach (Author author in model)
            {
                foreach (TitleAuthor ta in author.Titles)
                {
                    ta.Author = null;
                    if (ta.Title != null)
                    {
                        if (ta.Title.Publisher != null) ta.Title.Publisher.Titles = null;
                        ta.Title.Authors = null;
                    }
                }
            }
            return model;
        }

        [HttpGet("ByLastName/{lastName}")]
        public IActionResult Get(string lastName, int startRow = 1, int numberOfRows = 5)
        {
            int numberOfAuthors = 0;
            List<Author> authors = _pubsService.ListAuthorsByLastName(lastName, startRow, numberOfRows, out numberOfAuthors);
            if (startRow > 1)
            {
                ViewBag.PreviousClass = "previous";
                ViewBag.PreviousRow = startRow - numberOfRows;
            }
            else
            {
                ViewBag.PreviousClass = "previous disabled";
                ViewBag.PreviousRow = startRow;
            }
            if (startRow + numberOfRows > numberOfAuthors)
            {
                ViewBag.NextClass = "next disabled";
                ViewBag.NextRow = numberOfAuthors;
            }
            else
            {
                ViewBag.NextClass = "next";
                ViewBag.NextRow = startRow + numberOfRows;
            }
            ViewBag.TotalRows = numberOfAuthors;

            return PartialView("_AuthorList", authors);
        }

        // GET api/authors/111-11-1111
        [HttpGet("{id}")]
        public Author Get(string id)
        {
            // Get author
            Author model = _pubsService.GetAuthor(id);

            // Remove circular references - JSON serializer cannot handle them
            if (model != null)
            {
                foreach (TitleAuthor ta in model.Titles)
                {
                    ta.Author = null;
                    if (ta.Title != null)
                    {
                        if (ta.Title.Publisher != null) ta.Title.Publisher.Titles = null;
                        ta.Title.Authors = null;
                    }
                }
            }
            return model;
        }

        // POST api/authors
        [HttpPost]
        public void Post(Author author)
        {
            _pubsService.CreateAuthor(author);
        }

        // PUT api/authors/
        [HttpPut]
        public void Put(Author author)
        {
            _pubsService.UpdateAuthor(author);
        }

        // DELETE api/authors/111-11-1111
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _pubsService.DeleteAuthor(id);
        }
    }
}
