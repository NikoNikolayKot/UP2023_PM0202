//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UP2023_PM0202.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service
    {
        public int serviceID { get; set; }
        public int packageID { get; set; }
        public int typeServiceID { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string imagePath { get; set; }
        public byte[] image { get; set; }
    
        public virtual Package Package { get; set; }
        public virtual TypeService TypeService { get; set; }
    }
}
