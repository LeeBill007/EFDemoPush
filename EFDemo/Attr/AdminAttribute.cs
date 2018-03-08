using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDemo
{
    public class AdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 我們有在Action 上,定義AdminAttribute
            if (filterContext.ActionDescriptor.IsDefined(typeof(AdminAttribute), false))
            {
                if (filterContext.HttpContext.Session["Login"] is null)
                {
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "~/Views/Home/Login.cshtml"
                    };
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
