//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuthTreaning.ViewModel.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class GameOfUser
    {
        public long UserID { get; set; }
        public int GameID { get; set; }
    
        public virtual Game Game { get; set; }
    }
}