﻿//===============================================================================
// Microsoft FastTrack for Azure
// Application Insights Examples
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PubsRepository.Models
{
    [Serializable]
    public class TitleView
    {
        [Required]
        public string BookTitle { get; set; }
        public byte? AuthorOrder { get; set; }
        [Required]
        public string LastName { get; set; }
        public decimal? Price { get; set; }
        public int? YearToDateSales { get; set; }
        public string PublisherID { get; set; }
    }
}
