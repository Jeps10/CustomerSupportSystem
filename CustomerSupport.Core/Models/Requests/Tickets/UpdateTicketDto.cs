using System;
using System.Linq;
using System.Collections.Generic;
using CustomerSupport.EntityFramework.Entities;

namespace CustomerSupport.Core.Models
{
    public class UpdateTicketDto: BaseTicketDto
    {
        public long Id { get; set; }

        public override Dictionary<string, string> GetValidationErrors()
        {
            var errors = base.GetValidationErrors();
            if(Id == 0)
                errors.Add("Id", "Ticket Id does not exist.");

            return errors;
        }
    }
}