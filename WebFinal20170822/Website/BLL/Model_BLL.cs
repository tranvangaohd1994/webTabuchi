using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;
using System.Data;

namespace BLL
{
    public class Model_BLL
    {
        Model_DAL modelDAL = new Model_DAL();
        public List<string> SearchByChar(string model)
        {
            return modelDAL.SearchModelByChar(model);
        }
    }
}
