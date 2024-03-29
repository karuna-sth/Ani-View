﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AniView.Models;
using Microsoft.AspNetCore.Identity;

namespace AniView.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "VARCHAR(50)")]
    public string FirstName { get; set; }
    [PersonalData]
    [Column(TypeName = "VARCHAR(50)")]
    public string LastName { get; set; }

    public List<Review> ReviewList { get; set; }

}

