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
        public int? id_sotrudnika { get; set; }
        public DateTime date1 { get; set; }
        public string B { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string marka { get; set; }
        public DateTime date { get; set; }
        public string A { get; set; }
        public string name { get; set; }
        public string doljnost { get; set; }
        public string FIRST { get; set; }
        public string SECOND { get; set; }

    }


    public class SQLController : Controller
    {
        tax2Entities db = new tax2Entities();
        //
        // GET: /SQL/
        public ActionResult Index6()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index6(string str)
        {
            ObjectContext name = new ObjectContext("name=tax2Entities");
            Object[] parmetrers = new object[]
           {
               new MySqlParameter("name","1"),
               new MySqlParameter("val","1")
        };
            TempData["result"] = name.ExecuteStoreQuery<ResultType>(
                @"
 SELECT  'Voditel' AS 
SECOND
FROM sotrudnik
UNION (
SELECT DISTINCT sotrudnik.last_name AS 
SECOND
FROM sotrudnik
WHERE sotrudnik.doljnost = 'Voditel'
)
  


                ");

            return RedirectToAction("Result6");
        }

        public ActionResult Result6()
        {
            ViewBag.result = TempData["result"];
            TempData.Keep();
            return View();
        }






        public ActionResult Index5()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index5(string str)
        {
            ObjectContext name = new ObjectContext("name=tax2Entities");
            Object[] parmetrers = new object[]
           {
               new MySqlParameter("name","1"),
               new MySqlParameter("val","1")
        };
            TempData["result"] = name.ExecuteStoreQuery<ResultType>(
                @"
 SELECT  'dispetcher' AS 
FIRST 
FROM sotrudnik
UNION (
SELECT DISTINCT sotrudnik.last_name AS 
FIRST 
FROM sotrudnik
WHERE sotrudnik.doljnost = 'dispetcher'
)

                ");

            return RedirectToAction("Result5");
        }

        public ActionResult Result5()
        {
            ViewBag.result = TempData["result"];
            TempData.Keep();
            return View();
        }







        public ActionResult Index4()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index4(string str)
        {
            ObjectContext name = new ObjectContext("name=tax2Entities");
            Object[] parmetrers = new object[]
           {
               new MySqlParameter("name","1"),
               new MySqlParameter("val","1")
        };
            TempData["result"] = name.ExecuteStoreQuery<ResultType>(
                @"
 SELECT distinct sotrudnik.first_name, sotrudnik.last_name, tc.marka FROM zakaz 
INNER JOIN tc ON zakaz.id_TC=tc.id
INNER JOIN sotrudnik ON zakaz.id_sotrudnika=sotrudnik.id

                ");

            return RedirectToAction("Result4");
        }

        public ActionResult Result4()
        {
            ViewBag.result = TempData["result"];
            TempData.Keep();
            return View();
        }






        public ActionResult Index3()
        {
            ViewBag.sotrudnik = new SelectList(db.sotrudnik, "id", "last_name");
            return View();
        }

        [HttpPost]
        public ActionResult Index3(int sotrudnikId)
        {
            ObjectContext name = new ObjectContext("name=tax2Entities");
            Object[] parmetrers = new object[]
           {
               new MySqlParameter("sotrudnik",sotrudnikId)
               
        };
            TempData["result"] = name.ExecuteStoreQuery<ResultType>(
                @"
SELECT s1.last_name, tc.marka, vizov.`date` , zakaz.A, zakaz.B, tip_vizova.name
FROM zakaz
LEFT OUTER JOIN tc ON zakaz.id_TC = tc.id
LEFT OUTER JOIN sotrudnik s1 ON zakaz.id_sotrudnika = s1.id
LEFT OUTER JOIN vizov ON vizov.id_sotrudnika = s1.id
LEFT OUTER JOIN tip_vizova ON vizov.id_tip_vizova = tip_vizova.id
LEFT OUTER JOIN sotrudnik s2 ON vizov.id_sotrudnika = s2.id
WHERE s1.id = @sotrudnik 

                ", parmetrers);

            return RedirectToAction("Result3");
        }

        public ActionResult Result3()
        {
            ViewBag.result = TempData["result"];
            TempData.Keep();
            return View();
        }





        public ActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index2(string str)
        {
            ObjectContext name = new ObjectContext("name=tax2Entities");
            Object[] parmetrers = new object[]
           {
               new MySqlParameter("name","1"),
               new MySqlParameter("val","1")
        };
            TempData["result"] = name.ExecuteStoreQuery<ResultType>(
                @"
 SELECT distinct sotrudnik.first_name, sotrudnik.last_name, tc.marka FROM zakaz 
INNER JOIN tc ON zakaz.id_TC=tc.id
INNER JOIN sotrudnik ON zakaz.id_sotrudnika=sotrudnik.id

                ");

            return RedirectToAction("Result2");
        }

        public ActionResult Result2()
        {
            ViewBag.result = TempData["result"];
            TempData.Keep();
            return View();
        }

        
        
        
        
        public ActionResult Index1() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index1(string str)
        {
            ObjectContext name = new ObjectContext("name=tax2Entities") ;
            Object[] parmetrers = new object[]
           {
               new MySqlParameter("name","1"),
               new MySqlParameter("val","1")
        };
            TempData["result"] = name.ExecuteStoreQuery<ResultType>(
                @"
 SELECT id_sotrudnika 
FROM vizov
WHERE DATE
BETWEEN  '01.07.2010'
AND  '23.07.2010'
LIMIT 0 , 30

                ");

            return RedirectToAction("Result1");
        }

        public ActionResult Result1()
        {
            ViewBag.result = TempData["result"];
            TempData.Keep();
            return View();
        }



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
