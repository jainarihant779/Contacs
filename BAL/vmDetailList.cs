using Contacs.Models;
using Contacs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacs.BAL
{
    public class vmDetailList

    {
        private IDbAccess DBAccess { get; set; }
        public vmDetailList(IDbAccess DB)
        {
            DBAccess = DB;
        }
        public IEnumerable<Details> GetList()
        {
            IEnumerable<Details> contact = new List <Details>();

            contact = DBAccess.GetAllDetails();

            return contact;
        }


        public bool UpdateDetails(Details objdetails)
        {
            bool Result = false;
            try {
               
                DBAccess.UpdateDetails(objdetails);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
          }

        public bool AddContact(Details objdetails)
        {
            bool Result = false;
            try
            {
                DBAccess.AddContact (objdetails);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteContact(int? id)
        {
            bool Result = false;
            try
            {
                DBAccess.DeleteContact (id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
