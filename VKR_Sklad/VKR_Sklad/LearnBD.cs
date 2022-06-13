using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR_Sklad
{
    class LearnBD
    {
        
            private static VKRskladEntities _context;
            public static VKRskladEntities GetContext()
            {
                if (_context == null)
                    _context = new VKRskladEntities();
                return _context;
            }

        

    }
}
