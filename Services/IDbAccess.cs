using Contacs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacs.Services
{
  public  interface IDbAccess
    {
        public IEnumerable<Details> GetAllDetails();
        public void AddContact(Details objdetails);
        public void UpdateDetails(Details objdetails);
        public void DeleteContact(int? id);
    }
}
