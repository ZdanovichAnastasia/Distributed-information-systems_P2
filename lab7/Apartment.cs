using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    internal partial class Apartment : ApartmentBase
    {
        protected int Id { get; set; }
        protected string Region { get; set; }
    }
    internal partial class Apartment : ApartmentBase
    {
        override protected bool TryFindIfAdsElementExist(string param)
        {
            try
            {
                if (Region == param)
                    return true;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return false;
            }
        }
    }
}
