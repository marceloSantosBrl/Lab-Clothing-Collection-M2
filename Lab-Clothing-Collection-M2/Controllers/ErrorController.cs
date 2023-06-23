using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_Clothing_Collection_M2.Controllers;

[ApiController]
public class ErrorController : ControllerBase
{
    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult HandleError() =>
        Problem();
}