using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;
using System.Data;
namespace BLL
{
    public class Model_BLL_base
    {
        Model_DAL_base model = new Model_DAL_base();
        public DataTable ModelSelectAll()
        {
            return model.ModelSelectByAll();
        }

        public DataTable ModelSelectById(string _model)
        {
            return model.ModelSelectById(_model);
        }

        public bool ModelInsert(Model _model)
        {
            return model.ModelInsert(_model);
        }

        public bool ModelDelete(string _model)
        {
            return model.ModelDelete(_model);
        }
    }
}
