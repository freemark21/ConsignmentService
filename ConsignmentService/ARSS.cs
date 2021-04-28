﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsignmentService
{

    public class ARSSrootobject
    {
        public Ttblarss[] ttblarss { get; set; }
    }

    public class Ttblarss
    {
        public string[] addonno { get; set; }
        public string[] addonnum { get; set; }
        public string[] addr { get; set; }
        public string addr3 { get; set; }
        public bool addressoverfl { get; set; }
        public string allowfulfillmentty { get; set; }
        public string alternateid { get; set; }
        public string balintdatetm { get; set; }
        public string bankno { get; set; }
        public string billdirectaddon { get; set; }
        public bool bofl { get; set; }
        public string bolimit { get; set; }
        public bool bondedfl { get; set; }
        public string bondno { get; set; }
        public bool ccblockfl { get; set; }
        public string ccexp { get; set; }
        public string ccno { get; set; }
        public string city { get; set; }
        public string citycd { get; set; }
        public string classrating { get; set; }
        public string cono { get; set; }
        public string consolformat { get; set; }
        public string consolinterval { get; set; }
        public string consolinvty { get; set; }
        public string consolterms { get; set; }
        public bool copymaintfl { get; set; }
        public string countrycd { get; set; }
        public string countycd { get; set; }
        public string createdby { get; set; }
        public object createddt { get; set; }
        public string createdproc { get; set; }
        public string createdtm { get; set; }
        public string credlim { get; set; }
        public string custno { get; set; }
        public string custpo { get; set; }
        public string custshipto { get; set; }
        public string disccd { get; set; }
        public string divno { get; set; }
        public string dunsno { get; set; }
        public bool eackto { get; set; }
        public string eacktype { get; set; }
        public string easngrp { get; set; }
        public string easnto { get; set; }
        public string easntype { get; set; }
        public string ecommwhse { get; set; }
        public bool edi840fl { get; set; }
        public string ediackver { get; set; }
        public bool edicatprodfl { get; set; }
        public string edichgcd { get; set; }
        public string edictrlno { get; set; }
        public string[] edienvtag { get; set; }
        public string ediinvver { get; set; }
        public bool edijitfl { get; set; }
        public string edinetwork { get; set; }
        public bool edinsprodfl { get; set; }
        public string ediordcd { get; set; }
        public string edipartaddr { get; set; }
        public string edipartner { get; set; }
        public bool ediprcfl { get; set; }
        public bool ediprintnotesfl { get; set; }
        public bool editermsfl { get; set; }
        public string ediyouraddr { get; set; }
        public bool einvto { get; set; }
        public string einvtype { get; set; }
        public string email { get; set; }
        public string enterdt { get; set; }
        public bool epropto { get; set; }
        public string eproptype { get; set; }
        public string esbactioncode { get; set; }
        public object estcompdt { get; set; }
        public bool excsxapilstfl { get; set; }
        public string extshipinstr { get; set; }
        public string faxphoneno { get; set; }
        public string fpcustno { get; set; }
        public string frttermscd { get; set; }
        public string[] genaddr { get; set; }
        public string genaddr3 { get; set; }
        public string gencity { get; set; }
        public string gennm { get; set; }
        public string genphoneno { get; set; }
        public string genst { get; set; }
        public string genzip { get; set; }
        public string geocd { get; set; }
        public string gstreg { get; set; }
        public string holddays { get; set; }
        public bool holdfl { get; set; }
        public string holdpercd { get; set; }
        public bool inbndfrtfl { get; set; }
        public string industrytype { get; set; }
        public string intratodcd { get; set; }
        public bool invtofl { get; set; }
        public string invtotype { get; set; }
        public string jmjobid { get; set; }
        public string jmjobrevno { get; set; }
        public object jobclosedt { get; set; }
        public string jobcodbal { get; set; }
        public string jobdesc { get; set; }
        public string jobfutinvbal { get; set; }
        public string jobmisccrbal { get; set; }
        public string jobordbal { get; set; }
        public float[] jobperiodbal { get; set; }
        public string jobservchgbal { get; set; }
        public string jobuncashbal { get; set; }
        public string langcd { get; set; }
        public object lastconsoldt { get; set; }
        public object lastsaledt { get; set; }
        public string[] lenaddr { get; set; }
        public string lenaddr3 { get; set; }
        public string lencity { get; set; }
        public string lennm { get; set; }
        public string lenst { get; set; }
        public string lenzip { get; set; }
        public string lienamt { get; set; }
        public object lienfiledt { get; set; }
        public string lienfileoper { get; set; }
        public string lienpreamt { get; set; }
        public object lienpredt { get; set; }
        public string lienpreoper { get; set; }
        public string lienprewith { get; set; }
        public bool linetermsfl { get; set; }
        public bool lnshipcompfl { get; set; }
        public string mediacd { get; set; }
        public string name { get; set; }
        public object nextconsoldt { get; set; }
        public string noinvcopy { get; set; }
        public string nontaxtype { get; set; }
        public string notesfl { get; set; }
        public string obsedi { get; set; }
        public string operinit { get; set; }
        public string orderdisp { get; set; }
        public string ordrep1 { get; set; }
        public string ordrep2 { get; set; }
        public string ordrep3 { get; set; }
        public string ordrep4 { get; set; }
        public string ordrep5 { get; set; }
        public string orderreppct1 { get; set; }
        public string orderreppct2 { get; set; }
        public string orderreppct3 { get; set; }
        public string orderreppct4 { get; set; }
        public string orderreppct5 { get; set; }
        public string other1cd { get; set; }
        public string other2cd { get; set; }
        public bool outbndfrtfl { get; set; }
        public bool outofcityfl { get; set; }
        public string[] ownaddr { get; set; }
        public string ownaddr3 { get; set; }
        public string owncity { get; set; }
        public string ownnm { get; set; }
        public string ownst { get; set; }
        public string ownzip { get; set; }
        public string pdcustno { get; set; }
        public string phoneno { get; set; }
        public string picklabelprefix { get; set; }
        public string picklabelsize { get; set; }
        public string pickprno { get; set; }
        public string pocontctnm { get; set; }
        public string pophoneno { get; set; }
        public bool poreqfl { get; set; }
        public string pricecd { get; set; }
        public string pricetype { get; set; }
        public bool ptxapfl { get; set; }
        public bool ptxarfl { get; set; }
        public bool ptxtransbillfl { get; set; }
        public string ptxtype { get; set; }
        public string rebatety { get; set; }
        public string rowpointer { get; set; }
        public bool restricteditfl { get; set; }
        public bool restrictfl { get; set; }
        public object revestdt { get; set; }
        public string route { get; set; }
        public string salesamt { get; set; }
        public string salesterr { get; set; }
        public bool servchgfl { get; set; }
        public string shipinstr { get; set; }
        public string shiplbl { get; set; }
        public string shipto { get; set; }
        public string shiptoeasncd { get; set; }
        public string shiptogrp { get; set; }
        public string shipviaty { get; set; }
        public string[] siccd { get; set; }
        public string sigreqtype { get; set; }
        public string slslimitamt { get; set; }
        public string slsrepin { get; set; }
        public string slsrepout { get; set; }
        public string spcdefaultty { get; set; }
        public bool srallownegoverfl { get; set; }
        public object startdt { get; set; }
        public string state { get; set; }
        public string statecd { get; set; }
        public bool statustype { get; set; }
        public string strategicacct { get; set; }
        public bool subfl { get; set; }
        public bool synccrmfl { get; set; }
        public bool syncmddfl { get; set; }
        public string taxablety { get; set; }
        public string taxauth { get; set; }
        public string taxcert { get; set; }
        public object taxdt { get; set; }
        public string taxreg { get; set; }
        public string termstype { get; set; }
        public string transdt { get; set; }
        public string transferloc { get; set; }
        public DateTime transdttmz { get; set; }
        public string transproc { get; set; }
        public string transtm { get; set; }
        public string user1 { get; set; }
        public string user10 { get; set; }
        public string user11 { get; set; }
        public string user12 { get; set; }
        public string user13 { get; set; }
        public string user14 { get; set; }
        public string user15 { get; set; }
        public string user16 { get; set; }
        public string user17 { get; set; }
        public string user18 { get; set; }
        public string user19 { get; set; }
        public string user2 { get; set; }
        public string user20 { get; set; }
        public string user21 { get; set; }
        public string user22 { get; set; }
        public string user23 { get; set; }
        public string user24 { get; set; }
        public string user3 { get; set; }
        public string user4 { get; set; }
        public string user5 { get; set; }
        public string user6 { get; set; }
        public string user7 { get; set; }
        public string user8 { get; set; }
        public object user9 { get; set; }
        public string vattype { get; set; }
        public string webpage { get; set; }
        public string whse { get; set; }
        public string wodisccd { get; set; }
        public string zipcd { get; set; }
        public string arssRowID { get; set; }
    }

}
