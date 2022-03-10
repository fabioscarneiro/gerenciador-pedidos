﻿namespace Pedidos.Domain.Products
{
    public class Product : Entity
    {
        public Category? Category { get; set; }
        public Guid CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public bool HasStock { get; set; }
    }
}
