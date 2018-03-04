using System;
using Newtonsoft.Json;

namespace Restaurants.Models
{
    public class RestaurantGrade
    {
        [JsonProperty("date")]
        public DateTime date { get; set; }

        [JsonProperty("grade")]
        public string grade { get; set; }

        [JsonProperty("score")]
        public int? score { get; set; }

        public RestaurantGrade() {}
        public RestaurantGrade(DateTime date, string grade, int score)
        {
            this.date = date;
            this.grade = grade;
            this.score = score;
        }
    }
}