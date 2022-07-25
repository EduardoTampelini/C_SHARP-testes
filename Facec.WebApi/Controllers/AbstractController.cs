using Microsoft.AspNetCore.Mvc;
using System;

namespace Facec.WebApi.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        protected IActionResult InvokeMethod<T>(Action<T> method, T args)
        {
            try
            {
                method.Invoke(args);
                return Ok();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected IActionResult InvokeMethod<TResult>(Func<TResult> method)
        {
            try
            {
                return Ok(method.Invoke());
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}