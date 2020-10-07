using PropertyLettingsPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyLettingsPortal.Interfaces
{
    public interface IEmailService
    {
        void Send(string message, string from, Property property);
    }
}
