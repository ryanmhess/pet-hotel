using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pet_hotel
{
  public class PetOwner 
  {
    //  Owner ID
    public int id { get; set; }

    //  Owner Name (not null)
    [Required]
    public string name { get; set; }

    //  Owner Email (not null, valid format)
    [Required]
    public string emailAddress { get; set; }

    //  Owner number of pets
    public int petCount { get; set; }
  }
}
