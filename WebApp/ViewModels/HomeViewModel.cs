using BusinessModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class HomeViewModel
    {
        public Owner owner { get; set; }
        public List<profileItem> profileItems { get; set; }
    }
}
