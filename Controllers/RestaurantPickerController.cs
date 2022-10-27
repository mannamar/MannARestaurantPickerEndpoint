// Amardeep Mann
// 10-27-22
// Restaurant Picker - Endpoint
// Create a Restaurant Picker WebAPI project that takes in a cusine-type string variable via the URL and presents the user with a randomly generated restaurant to eat at of that type
// Peer Review by Marcel R.: Program ran perfectly, I liked how if you don't include a type of food in the url it'll return one from all three categories. Nice use of arrays and if statements, and the inclusion of .ToLower(). Awesome work! :D

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MannARestaurantPicker.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class RestaurantPickerController : ControllerBase
  {
    [HttpGet]
    public string RestaurantPickerDefault()
    {
      string[] mexPlaces = { "Taco Bell", "Chipotle", "Tacos Chapala", "Flakkos Tacos", "Jimboy's Tacos", "Tepa Taqueria", "El Senor Frogs", "Tacos La Palmita", "Taqueria El Grullense", "Casa Flores" };
      string[] fastPlaces = { "McDonalds", "Taco Bell", "Burger King", "Carl's Jr", "Wendy's", "Papa John's", "Pizza Hut", "Jack in the Box", "In-n-Out", "Raising Cane's" };
      string[] asianPlaces = { "Panda Express", "Pho Island", "Spice It Up!", "Jimmies Place", "Maroo Korean BBQ", "Thai Me Up", "Green Papaya", "ShoMi", "Komachi Sushi", "Jitaro Japanese Food Truck" };
      Random randNum = new Random();
      int userNumInt = randNum.Next(1, 4);
      string[] userPlaces = { };
      if (userNumInt == 1)
      {
        userPlaces = mexPlaces;
      }
      else if (userNumInt == 2)
      {
        userPlaces = fastPlaces;
      }
      else if (userNumInt == 3)
      {
        userPlaces = asianPlaces;
      }
      return $"Cusine type: Any\n\nYou should try {userPlaces[randNum.Next(0, userPlaces.Length)]}!";
    }

    [HttpGet("{cuisineType}")]

    public string RestaurantPicker(string cuisineType)
    {
      string[] mexPlaces = { "Taco Bell", "Chipotle", "Tacos Chapala", "Flakkos Tacos", "Jimboy's Tacos", "Tepa Taqueria", "El Senor Frogs", "Tacos La Palmita", "Taqueria El Grullense", "Casa Flores" };
      string[] fastPlaces = { "McDonalds", "Taco Bell", "Burger King", "Carl's Jr", "Wendy's", "Papa John's", "Pizza Hut", "Jack in the Box", "In-n-Out", "Raising Cane's" };
      string[] asianPlaces = { "Panda Express", "Pho Island", "Spice It Up!", "Jimmies Place", "Maroo Korean BBQ", "Thai Me Up", "Green Papaya", "ShoMi", "Komachi Sushi", "Jitaro Japanese Food Truck" };
      Random randNum = new Random();
      int userNumInt = randNum.Next(1, 4);
      string[] userPlaces = { };
      if (cuisineType.ToLower() == "mexican")
      {
        cuisineType = "Mexican";
        userPlaces = mexPlaces;
      }
      else if (cuisineType.ToLower() == "fastfood" || cuisineType.ToLower() == "fast food" || cuisineType.ToLower() == "fast-food")
      {
        cuisineType = "Fast-Food";
        userPlaces = fastPlaces;
      }
      else if (cuisineType.ToLower() == "asian")
      {
        cuisineType = "Asian";
        userPlaces = asianPlaces;
      }
      else
      {
        return "Please enter a valid cuisine type. Valid options are: Mexican, Asian, and Fast-Food";
      }
      return $"Cusine type: {cuisineType}\n\nYou should try {userPlaces[randNum.Next(0, userPlaces.Length)]}!";
    }
  }
}