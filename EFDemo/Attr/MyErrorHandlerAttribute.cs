using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDemo
{
    public class MyErrorHandlerAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var errorMsg = $"Error Msg: {filterContext.Exception.GetBaseException().Message}";
            // 
            //if (filterContext.HttpContext.Request.IsAjaxRequest())
            //{
            //    filterContext.Result = new JsonResult() { Data = "{errorMsg:  }" };
            //}
            //else
            //{
            //}

            filterContext.Result = new ViewResult()
            {
                ViewName = "~/Views/Shared/Error.cshtml",
                ViewData = new ViewDataDictionary(new Model.ErrorModel
                {
                    ErrorMsg = errorMsg,
                    ControllerName = filterContext.Controller.ToString()
                })
            };
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            filterContext.ExceptionHandled = true;
        }
    }
}