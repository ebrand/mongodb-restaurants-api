using System;

namespace Restaurants.Models
{
    public class RestaurantGrade
    {
        public DateTime Date { get; set; }

        public string LetterGrade { get; set; }

        public int? NumericScore { get; set; }

        public RestaurantGrade() {}
        public RestaurantGrade(DateTime date, string grade, int score)
        {
            this.Date = date;
            this.LetterGrade = grade;
            this.NumericScore = score;
        }
    }
}