using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class HomeDTO
    {
        public string HeaderName { get; set; }
        public long TakenTime_EF { get; set; }
        public long TakenTime_Dapper { get; set; }
        public long TakenTime_ADO { get; set; }
        public long TakenTime_EFwithSP { get; set; }

    }
}
