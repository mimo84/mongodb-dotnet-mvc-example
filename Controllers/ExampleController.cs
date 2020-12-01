using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mongodb_driver_example.Models;
using mongodb_driver_example.Services;
using System.Threading.Tasks;

namespace mongodb_driver_example.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ExampleController : ControllerBase
  {
    private readonly ExampleService _exampleService;

    public ExampleController(ExampleService exampleService)
    {
      _exampleService = exampleService;
    }

    [HttpGet]
    public List<Example> Get()
    {
      return _exampleService.FetchAll();
    }

    public async Task<Example> CreateAsync([FromBody] Example example)
    {
      await _exampleService.CreateAsync(example);
      return example;
    }

  }
}

