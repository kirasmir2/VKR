using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR_Sklad
{
    class LearnBD
    {
        
            private static VKR_SkladEntities _context;
            public static VKR_SkladEntities GetContext()
            {
                if (_context == null)
                    _context = new VKR_SkladEntities();
                return _context;
            }

        

    }
}
