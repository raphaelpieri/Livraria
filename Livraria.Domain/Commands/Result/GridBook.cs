﻿using System;

namespace Livraria.Domain.Commands.Result
{
    public class GridBook
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PublishingCompany { get; set; }
        public string Author { get; set; }
        public decimal Value { get; set; }
    }
}