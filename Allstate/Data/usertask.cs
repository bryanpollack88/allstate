//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Allstate.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class usertask
    {
        ///<summary>Task primary key</summary>
        public int id { get; set; }
        ///<summary>Description of task</summary>
        public string title { get; set; }
        ///<summary>Due date of task</summary>
        public System.DateTime completedate { get; set; }
        ///<summary>UserID corresponding to Username</summary>
        public int userid { get; set; }
        ///<summary>Indicates if task is complete</summary>
        public bool taskcomplete { get; set; }
        ///<summary>Date task created</summary>
        public byte[] insertdate { get; set; }
    
        public virtual user user { internal get; set; }
    }
}
