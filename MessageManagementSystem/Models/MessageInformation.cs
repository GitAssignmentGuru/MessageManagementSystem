//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MessageManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MessageInformation
    {
        public string ClientID { get; set; }
        public string Message { get; set; }
        public int NumberOfdays { get; set; }
        public System.DateTime StartDate { get; set; }
        public decimal CostofUnit { get; set; }
        public bool Status { get; set; }
    
        public virtual ClinetInformation ClinetInformation { get; set; }
    }
}