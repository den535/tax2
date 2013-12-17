using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Objects;
using MySql.Data.MySqlClient;

namespace tax2.Controllers
{
    public class ResultType 
    {
        public int id_sotrudnika { get; set; }
        public DateTime date1 { get; set; }
        public string B { get; set; }
    }


    public class SQLController : Controller
    {
        //
        // GET: /SQL/

        public ActionResult Index() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string str)
        {
            ObjectContext name = new ObjectContext("name=tax2Entities") ;
            Object[] parmetrers = new object[]
           {
               new MySqlParameter("name","1"),
               new MySqlParameter("val","1")
        };
            TempData["result"] = name.ExecuteStoreQuery<ResultType>(
                @"
 SELECT v.date date1, z.id_sotrudnika, z.B FROM vizov v          
     INNER JOIN zakaz z
     ON z.id_sotrudnika = v.id_sotrudnika"
                );
            
            return RedirectToAction("Result");
        }

        public ActionResult Result()
        {
        ViewBag.result = TempData["result"];
        TempData.Keep();
            return View();
        }
    }
}
