using BethenysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethenysPieShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
    }
}
