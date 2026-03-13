using Microsoft.AspNetCore.Mvc;
using UserApp.Models;

namespace UserApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static List<Product> products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 1200 },
        new Product { Id = 2, Name = "Mouse", Price = 25 },
        new Product { Id = 3, Name = "Keyboard", Price = 45 },
        new Product { Id = 4, Name = "Monitor", Price = 300 },
        new Product { Id = 5, Name = "Headphones", Price = 80 },
        new Product { Id = 6, Name = "Webcam", Price = 60 },
        new Product { Id = 7, Name = "External Hard Drive", Price = 150 },
        new Product { Id = 8, Name = "USB-C Hub", Price = 40 },
        new Product { Id = 9, Name = "Gaming Chair", Price = 250 },
        new Product { Id = 10, Name = "Microphone", Price = 110 }
    };


    [HttpGet("getAllProducts")]
    public IActionResult GetProducts()
    {
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        product.Id = products.Count + 1;
        products.Add(product);

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }
}
