//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tax2
{
    using System;
    using System.Collections.Generic;
    
    public partial class sotrudnik
    {
        public sotrudnik()
        {
            this.zakaz = new HashSet<zakaz>();
            this.vizov = new HashSet<vizov>();
        }
    
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string doljnost { get; set; }
    
        public virtual ICollection<zakaz> zakaz { get; set; }
        public virtual ICollection<vizov> vizov { get; set; }
    }
}
