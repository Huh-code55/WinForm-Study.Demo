using MTHDAL;
using MTHModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHBLL
{
    public class ActualDataManage
    {
        private ActualDataService actualDataService = new ActualDataService();

        public bool AddActualData(ActualData actualData)
        {
            return actualDataService.AddActualData(actualData) == 1;
        }

        public DataTable QueryActualDataByCondition(string start, string end, List<string> columns)
        {
            return actualDataService.QueryActualDataByCondition(start, end, columns);
        }
    }
}
