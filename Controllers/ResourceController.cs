using System.Web.Mvc;

namespace Task.Controllers
{

    public class ResourceController : BaseController
    {
        [HttpGet]
        public JsonResult GetResourceStrings()
        {
            var resourceStrings = new
            {
                ItemDeleted= Resource.Resource.ItemDeleted,
                titleMsg=Resource.Resource.titleMsg,
                textMsg=Resource.Resource.textMsg,
                cancel= Resource.Resource.lbcancelButtonText,
                lbOk=Resource.Resource.lbOk,
                lbconfirmButtonText=Resource.Resource.lbconfirmButtonText,
                confirm= Resource.Resource.confirm,
            };

            return Json(resourceStrings, JsonRequestBehavior.AllowGet);
        }
    }

}