using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace tax2
{
    [MetadataType(typeof(tcDataAnnotations))]
    public partial class tc
    {
    }
    public class tcDataAnnotations
    {
        [Display(Name = "Цвет")]
        public string color { get; set; }

        [Display(Name = "Марка")]
        public string marka { get; set; }

        [Display(Name = "Номер")]
        public string nomer { get; set; }
    }

    [MetadataType(typeof(sotrudnikDataAnnotations))]
    public partial class sotrudnik
    {
    }
    public class sotrudnikDataAnnotations
    {


        [Display(Name = "Должность")]
        public string doljnost { get; set; }
        [Display(Name = "Имя")]
        public string first_name { get; set; }
        [Display(Name = "Фамилия")]
        public string last_name { get; set; }

    }

    [MetadataType(typeof(zakazDataAnnotations))]
    public partial class zakaz
    {
    }
    public class zakazDataAnnotations
    {



       
        [Display(Name = "A")]
        public string A { get; set; }
        [Display(Name = "B")]
        public string B { get; set; }

    }

    [MetadataType(typeof(vizovDataAnnotations))]
    public partial class vizov
    {
    }
    public class vizovDataAnnotations
    {



      
        [Display(Name = "Дата")]
        public DateTime date { get; set; }
        [Display(Name = "id сотрудника")]
        public int id_sotrudnika { get; set; }
        


    }

    [MetadataType(typeof(tip_vizovaDataAnnotations))]
    public partial class tip_vizova
    {
    }
    public class tip_vizovaDataAnnotations
    {




        [Display(Name = "Ввод/вывод")]
        public bool vxod_vixod;
        [Display(Name = "состояние")]
        public string name { get; set; }


    }
}