using ApiLayer.DAL.ApiContext;
using ApiLayer.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       public Context c = new Context();
        [HttpGet]
        public IActionResult CategoryList()
        {
            
            var values = c.Categories.ToList();
            
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            c.Add(p);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("id")]
        public IActionResult GetCategory(int id) 
        {
            var values= c.Categories.Find(id);
            if(values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);  
            }

        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var values= c.Categories.Find(id);
            if (values==null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(values);
                c.SaveChanges();
                return Ok();
            }
          

        }

        [HttpPut]
        public IActionResult UpdateCategory(Category p)
        {
            var values = c.Categories.Find(p.CategoryID);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                values.Name = p.Name;
                c.Update(values);
                c.SaveChanges();
                return Ok();
            }
           
        }
    }
}
