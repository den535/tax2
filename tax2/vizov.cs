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
    
    public partial class vizov
    {
        public int id { get; set; }
        public System.DateTime date { get; set; }
        public int id_sotrudnika { get; set; }
        public int id_tip_vizova { get; set; }
        public int id_zakaza { get; set; }
    
        public virtual tip_vizova tip_vizova { get; set; }
        public virtual zakaz zakaz { get; set; }
        public virtual sotrudnik sotrudnik { get; set; }
    }
}
