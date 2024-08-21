using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmFProj.ViewModels;

namespace MvvmFProj.Models
{
    internal class User  
    {
        public string? name { get; set; }
        public string? userName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? phoneNumber { get; set; }
        public DateTime birthDate { get; set; }
        public string? age { get; set; }

        

    }
}
