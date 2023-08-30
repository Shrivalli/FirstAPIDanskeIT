using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //Data Annotation - compiler to understand
    public class ProductController : ControllerBase
    {
        public static List<Product> Products = new List<Product>();
        public Product p = new Product();

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            Products = await p.GetAllProducts();
            return Ok(Products);
        }

        [HttpGet]
        [Route("GetProdById")]
        public async Task<ActionResult> GetProductByID(int pid)
        {
            if(pid.Equals(0))
            {
                return BadRequest("Id not supplied");
            }
            var p=Product.GetProductById(pid);
            if (p == null)
            {
                return NotFound("Product not Found");
            }
            return Ok(p);
        }

        [HttpPost]
        public ActionResult AddNewProduct(Product p)
        {
            if (p != null)
            {
                Product.AddProduct(p);
                return Ok();
            }
            else
                return BadRequest("Product not supplied");
        }

        [HttpDelete]
        public ActionResult RemoveProduct(int id)
        {
            Product.DeleteProduct(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateProduct(int id,Product p) 
        {
            if(id==null)
            {
                return BadRequest("Id not provided");
            }
            Product.EditProduct(id, p);
            return Ok();
        }
    }
}
