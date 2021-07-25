using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Abstract
{
    public interface IHomeRepository
    {
        IList<HomeDTO> GetPerfomanceDetails();
    }
}
