using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ERPP_WebSL
{
     class Functions
    {
        public Boolean isnumeric(string Qty)
        {
            double myVal = 0;
            if (Double.TryParse(Qty, out myVal))
                return true;
            else
                return false;
        }
        public string ReturnStrOutputSp(string DataIn, int Point)
        {
            int i,j;
            while (Point>=1)
            {
               // Console.Write(DataIn);
                i = DataIn.IndexOf("<Parameter ByRef=\"Y\">");
                j = DataIn.IndexOf("<Parameter ByRef=\"Y\" />");
                if (j < i && j>-1 && Point==1)
                {
                    DataIn = "";
                }
                else if ((i < j || j==-1) && i > -1)
                {
                    DataIn = DataIn.Substring(i + 21);
                }
                else
                {
                    DataIn = DataIn.Substring(j + 23);
                }
            Point = Point - 1;
            }

            if (DataIn != "")
            {
                DataIn = DataIn.Substring(0, DataIn.IndexOf("</Parameter>"));
            }
            

            return DataIn;
        }

        public bool checkloc(string loc)
        {
            try
            {
                CaLLIDO IDO = new CaLLIDO();
                DataTable clot = IDO.GetList("SLLocations", "Loc",
                string.Format("Loc='{0}'", loc), "", 0);
                if (clot.Rows.Count == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool checkLotloc(string whse, string loc, string item, string lot)
        {
            try
            {
                CaLLIDO IDO = new CaLLIDO();
                //SL.SLLotLocs
                DataTable clot = IDO.GetList("SLLotLocs", "Whse,Item,Loc,Lot",
                string.Format("Item='{0}' and Whse='{1}' and Loc='{2}' and Lot='{3}'", item, whse, loc, lot), "", 0);
                if (clot.Rows.Count == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Boolean checkQtyOnHand(string whse, string loc, string item, string lot,decimal Qty)
        {
            try
            {
                CaLLIDO IDO = new CaLLIDO();
                String LotTracked,SerialTracked;
                DataTable tagbar = IDO.GetList("SLItems", "Item,Description,SerialTracked,LotTracked,UM",
                string.Format("Item='{0}'", item), "", 1);
               // Cursor.Current = Cursors.Default;
                if (tagbar.Rows.Count == 0)
                    return false;
                else
                {
                    LotTracked = tagbar.Rows[0]["LotTracked"].ToString();
                    SerialTracked = tagbar.Rows[0]["SerialTracked"].ToString();
                }

                //SL.SLLotLocs
                if (SerialTracked == "1" && Qty!=1)
                    return false;
                else if (LotTracked == "1")
                {
                    DataTable clot = IDO.GetList("SLLotLocs", "QtyOnHand,Whse,Item,Loc,Lot",
                    string.Format("Item='{0}' and Whse='{1}' and Loc='{2}' and Lot='{3}' and QtyOnHand>={4}", item, whse, loc, lot, Qty), "", 0);
                    if (clot.Rows.Count == 0)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    DataTable clot = IDO.GetList("SLItemLocs", "QtyOnHand,Whse,Item,Loc",
                    string.Format("Item='{0}' and Whse='{1}' and Loc='{2}' and QtyOnHand>={3}", item, whse, loc, Qty), "", 0);
                    if (clot.Rows.Count == 0)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}