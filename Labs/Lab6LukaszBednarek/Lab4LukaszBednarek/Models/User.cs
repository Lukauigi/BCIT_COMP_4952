using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Lab4LukaszBednarek.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class User : IdentityUser
    {
        [NotMapped]
        public IList<string> RoleNames { get; set; }
    }
}
