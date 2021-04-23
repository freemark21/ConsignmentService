using System;
using System.Collections.Generic;
using System.Text;

namespace ConsignmentService
{
    public class Rootobject
    {
        public Ttblsastaz[] Ttblsastaz { get; set; }
    }

    public class Ttblsastaz
    {
        public string Codeiden { get; set; }
        public string[] Codeval { get; set; }
        public int Cono { get; set; }
        public bool Labelfl { get; set; }
        public string Operinit { get; set; }
        public string Primarykey { get; set; }
        public object Rowpointer { get; set; }
        public string Secondarykey { get; set; }
        public string Transdt { get; set; }
        public string Transproc { get; set; }
        public string Transtm { get; set; }
        public string User1 { get; set; }
        public string User2 { get; set; }
        public string User3 { get; set; }
        public string User4 { get; set; }
        public string User5 { get; set; }
        public string User6 { get; set; }
        public string User7 { get; set; }
        public object User8 { get; set; }
        public object User9 { get; set; }
        public string SastazRowID { get; set; }
    }

}
