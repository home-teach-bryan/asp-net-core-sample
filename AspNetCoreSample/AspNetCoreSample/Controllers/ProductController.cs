using AspNetCoreSample.Models.Request;
using AspNetCoreSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }


    [HttpPost]
    [Route("")]
    public IActionResult AddProduct([FromBody] AddProductRequest request)
    {
        var result = _productService.AddProduct(request);
        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductRequest request)
    {
        var result = _productService.UpdateProduct(id, request);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteProduct([FromRoute] Guid id)
    {
        var result = _productService.RemoveProduct(id);
        return Ok(result);
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetProducts()
    {
        var result = _productService.GetAllProducts();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetProduct([FromRoute] Guid id)
    {
        var result = _productService.GetProduct(id);
        return Ok(result);
    }


}