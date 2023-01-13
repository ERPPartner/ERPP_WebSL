using System;
using System.Data;
using System.Collections.Generic;
using System.Text;


namespace ERPP_WebSL
{
    class CaLLIDO
    {
        
        public DataTable GetList(string CollectionName, string ObjectName, string WhereCase, string ValueSort, int NumOfReturn)
        {
            try
            {
                DataTable DTable = Login.webService.LoadDataSet(ShareData.SecID,
                                        CollectionName,
                                        ObjectName,
                                        WhereCase,
                                        ValueSort,
                                        "",
                                        NumOfReturn).Tables[0];
                    return DTable;
             }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
