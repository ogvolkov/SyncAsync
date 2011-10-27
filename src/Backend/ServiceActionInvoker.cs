using System.Web.Mvc;
using Contracts;

namespace Web
{
    /// <summary>
    /// Real magic happens here. For all actions that return IValue type, controller serializes the result into JSON for further frontend consumption.
    /// As a result, you don't need to do any manual wrapping of your DTO results into Action results and controllers can directly implement the shared interface.
    /// </summary>
    public class ServiceActionInvoker: ControllerActionInvoker
    {
        protected override ActionResult CreateActionResult(ControllerContext controllerContext,
         ActionDescriptor actionDescriptor, object actionReturnValue)
        {
            if (actionReturnValue is ActionResult)
            {
                return actionReturnValue as ActionResult;
            }
            else
            {
                if (actionReturnValue is IValue)
                {                                        
                    return new JsonResult
                               {
                                   Data = (actionReturnValue as IValue).Value,
                                   JsonRequestBehavior = JsonRequestBehavior.AllowGet
                               };
                }
                return null;                
            }
        }

    }
}