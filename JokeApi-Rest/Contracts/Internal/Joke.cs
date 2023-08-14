using System.Text.Json.Serialization;

public class Joke{
    public String id{get;set;}
    public String joke{get;set;}

    public override string ToString()
    {
        return $"id : {id} joke : {joke}";
    }
}