namespace RandomCats.Scripts
{
    internal class Models
    {
        public class ApiResponse
        {
            public bool Success { get; set; }
            public int Status { get; set; }
            public string Message { get; set; }
        }

        public class TheCatApi
        {
            // public string Id { get; set; }
            public string Url { get; set; }
            // public int Width { get; set; }
            // public int Height { get; set; }
        }

        public class Breed
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Alt_names { get; set; }
            public string Description { get; set; }

            public string Origin { get; set; }

            public string Life_span { get; set; }
            public int Adaptability { get; set; }
            public int Affection_level { get; set; }
            public int Child_friendly { get; set; }

            public int Dog_friendly { get; set; }
            public int Energy_level { get; set; }
            public int Grooming { get; set; }
            public int Health_issues { get; set; }

            public int Intelligence { get; set; }
            public int Shedding_level { get; set; }
            public int Social_needs { get; set; }
            public int Vocalisation { get; set; }

            public int Experimental { get; set; }
            public int Hairless { get; set; }
            public int Natural { get; set; }
            public int Rare { get; set; }

            public int Rex { get; set; }
            public int Suppressed_tail { get; set; }
            public int Short_legs { get; set; }
            public string Wikipedia_url { get; set; }
        }
    }
}
