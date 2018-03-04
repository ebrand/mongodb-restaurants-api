using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Restaurants.Models
{
    [BsonIgnoreExtraElements]
    public class RestaurantGrade
    {
        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("grade")]
        public string Grade { get; set; }

        [BsonElement("score")]
        public int? Score { get; set; }

        public RestaurantGrade() {}
        public RestaurantGrade(DateTime date, string grade, int score)
        {
            this.Date = date;
            this.Grade = grade;
            this.Score = score;
        }
    }
}