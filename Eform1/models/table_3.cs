﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eform1.models
{
    public class table_3
    {
        //[Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid idtable_3s { get; set; }
       // [Key]
      //  public int idtable_3s { get; set; }

        //[ForeignKey("table_2")]
       [Key]
        public int F2 { get; set; }

       
        // public int DUM1 { get; set; }
        
        public int UID_Q { get; set; }
        public int ID_MCQ { get; set; }
        public string Options { get; set; }

        //public table_4 table_4 { get; set; } [ForeignKey("table_4")]
    }
}
