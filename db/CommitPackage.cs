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
    
    public partial class CommitPackage
    {
        public int commitPackageID { get; set; }
        public int clientID { get; set; }
        public int packageID { get; set; }
        public string commitPackage1 { get; set; }
        public System.DateTime date { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Package Package { get; set; }
    }
}
