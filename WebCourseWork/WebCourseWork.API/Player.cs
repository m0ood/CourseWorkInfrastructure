namespace WebCourseWork.API
{
    public class Player
    {
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Currentteam { get; set; }
        public double Rating { get; set; }
        public Player(string nickname, string firstName, string lastName, int age, string currentteam, double rating)
        {
            Nickname = nickname;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Currentteam = currentteam;
            Rating = rating;
        }
    }
}
