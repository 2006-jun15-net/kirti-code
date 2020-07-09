using System;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldWebApp.Controllers
{
    public class HelloController :Controller
    {
        //this class can contain action methods and non action methods

        public IActionResult Hello1()
        {
            var result = new ContentResult
            {
                StatusCode = 200,
                ContentType = "text/html",
                Content = "<html>\n" +
                        "<head></head>\n" +
                        "<body>\n" +
                            "Hello controller\n" +
                        "</body>" +
                        "</html>"
            };
            return result;
        }

        [NonAction] // by default my instance method in this class might get called to handle a request
                    // might be an action method

        public void HelperMethod()
        {

        }
        
    }
}
