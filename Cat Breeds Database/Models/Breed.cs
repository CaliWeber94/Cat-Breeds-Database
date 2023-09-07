namespace Cat_Breeds_Database.Models
{
    public class Breed
    {
       public Breed() { }   
        public int breed_id { get; set; }   
        public string breed_name { get; set; }  

        public string origin { get; set; }  
        public string description { get; set; } 
        public int avg_lifespan { get; set; }   

        public string image { get; set; }
    }
}
