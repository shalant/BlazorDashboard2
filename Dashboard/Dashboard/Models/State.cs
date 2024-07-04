namespace Dashboard.Models;

public class State
{
    public string name { get; set; }
    public string postal { get; set; }
    public Capital capital { get; set; }
    public Population population { get; set; }
}

public class Capital
{
    public string name { get; set; }
    public string latitude { get; set; }
    public string longitude { get; set; }
}

public class Population
{
    public string density_km { get; set; }
    public string total { get; set; }
    public string density_mi { get; set; }
}



// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);


public class Root
{


}

