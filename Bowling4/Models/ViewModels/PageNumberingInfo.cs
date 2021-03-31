using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling4.Models.ViewModels
{
    public class PageNumberingInfo
    {
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        //Calcuate the Number of Pages
        public int NumPages => (int)Math.Ceiling((decimal)TotalNumItems / NumItemsPerPage);
    }
}
