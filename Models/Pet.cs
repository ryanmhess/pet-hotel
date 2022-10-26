using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    //  Pet Breed
    public enum PetBreedType 
    {
      Beagle,     //  0
      Boxer,      //  1
      Bulldog,    //  2
      Labrador,   //  3
      Poodle,     //  4
      Retriever,  //  5
      Shepherd,   //  6
      Terrier     //  7
    }

    //  Pet Color
    public enum PetColorType 
    {
      Black,      //  0
      Goldern,    //  1
      Spotted,    //  2
      Tricolor,   //  3
      White       //  4
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
