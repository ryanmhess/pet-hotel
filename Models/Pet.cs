using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    //  Pet Breed
    public enum PetBreedType 
    {
      Shepherd,
      Poodle,
      Beagle,     
      Bulldog,    
      Terrier,  
      Boxer,      
      Labrador,   
      Retriever  
    }

    //  Pet Color
    public enum PetColorType 
    {
      White,
      Black,
      Golden,
      Tricolor,
      Spotted
    }

  public class Pet
  {
    //  Pet ID
    public int id { get; set; }

    //  Pet Name
    [Required]
    public string name { get; set; }

    //  Pet Breed
    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetBreedType breed { get; set; }

    //  Pet Color
    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetColorType color { get; set; }

    //  DateTime of check in
    public DateTime? checkedInAt { get; set; }

    //  Pet Owner ID
    [ForeignKey("petOwner")]
    public int petOwnerId { get; set; }
    public PetOwner petOwner { get; set; }
  }
}
