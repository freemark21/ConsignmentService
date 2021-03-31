using System;
using System.Collections.Generic;
using System.Text;

namespace ConsignmentService
{
    public static class DBhelper
    {
        public static string CnnVal(string name)
        {
            return "Server=REP-WWW;Database=ConsignmentReturns;Trusted_Connection=True;";
        }
    }
}
